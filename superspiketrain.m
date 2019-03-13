classdef superspiketrain
    % SST = superspiketrain(tankname,blocklist,channel,unit,variable) will
    % create a superspiketrain object for reading in TDT data from unit on
    % channel on blocklist from tankname.
    % example sst = superspiketrain('R:\2Data\AOSData\AOS003',10,62,1,true)
    %
    % [SST, WaveData, SortCode] = superspiketrain(...,'waveforms') will
    % load a superspiketrain object as well as the waveforms collected for
    % the classification data requested.
    %
    % For this to work, the following TDT programs must be installed:
    %   1. TDT Drivers
    %   2. TDT ActiveXControls (password = spider)
    %   3.
    %
    % All TDT Passwords:
    %   Open Ex: Dragonfly
    %   Active X drivers: spider
    %   Open Explorer: swallowtail 
    %   Open Sorter: tupelo
    %   OpenDeveloper v2.8: killerbee
    %   BioSigRP: cicada
    %   BioSigRZ: elephant
    %   SigGenRP: grasshopper
    %   SigPlayRP beetle
    %
    % If all inputs are left blank, superspiketrain will default to reading
    % all units on all channels in all blocks of tank NIHL002. Leaving
    % blocks, channellist or unitnum blank will attempt to get all of the
    % indicated variable from the requested tank.
    %
    % Variable input arguments include:
    %
    % 'graphics'        generate plots from associated requests
    %
    % 'debug'           display debugging strings during operation
    %
    % 'timing'          calculate execution times and display them
    %
    % 'timestamps'      read in time stamps for the associated
    %                   block,channel and unit numbers
    %
    % 'waveforms'       to read in waveforms for the associated block,
    %                   channel and unit numbers; This data will be put
    %                   into two arrays not associated with the
    %                   superspiketrain structure
    %
    % 'sortcode'        Supply the sort id to use for identifying the
    %                   unit number. See TDT documentation for further
    %                   reference on correct code identification.
    %
    % 'SORTID'          see sortcode
    %
    % Example
    %   tankname = '\\khri-ses.adsroot.itcs.umich.edu\ses\DavidM\NIHL012';
    %   blocklist = [1 2 10 15];
    %   channel = 1;
    %   unit = 1;
    %   var1 = 'timestamps'
    %   var2 = 'timing'
    %
    %   SST = superspiketrain(tankname,blocklist,channel,unit[,var1,var2])
    %
    %   This call will open tank 'U:\DavidM\NIHL012' and will access unit 1
    %   on channel 1 of blocks 1,2,10 and 15 and will read in the time stamps
    %   for those trials as well as calculate the time required for various
    %   function calls made by the program.
    %
    % Example
    %   tankname = '\\khri-ses.adsroot.itcs.umich.edu\sesDavidM\NIHL012';
    %   blocklist = [1 2 10 15];
    %   channel = 1;
    %   unit = 1;
    %   variable = {'waveforms'};
    %
    %   [SST, WaveData, SortCode] = superspiketrain(...)
    %
    %   This will get the requested TDT data as well as the waveforms for
    %   that data.
    
    
    
    %
    % This data structure is designed to store the time stamp information
    % about an entire sequence of events generated from a Tucker Davis
    % Technologies neural data acquisition system. A proper tank structure,
    % block structure, channel and epoc indexing are required to use this
    % object.
    %
    % With proper object initialization, this data structure has several
    % built in routines for data analysis; these include: PSTH plotting,
    % Raster plotting, generalized 2-D spike intensity plotting, average
    % rate calculation, and TDT tank structure commands for further
    % independent development. This structure also provides several
    % fundamental routines associated with data parsing for independent
    % script development.
    %
    % Authors: David Martel and Seth Koehler
    %          Kresge Hearing Research Institute
    %          Department of Otolaryngology
    %          University of Michigan, Ann Arbor
    %
    
    %Completely documented
    properties
        
        
        %% Fingerprint Data from User
        
        %String identifying the path and tankname; if tank is registered
        %with TTank then tankname alone can be used.
        %
        %Debugging tank name:
        %'\\khri-ses.adsroot.itcs.umich.edu\sesDavidM\Spiketrain Class\Demo Tank'
        Tank='';
        
        %Unique Block numbers and coressponding string names of the form
        %'Block-XX'; numbers are positive integers greater than 0.
        Block=[];
        
        %Unique Block numbers and coressponding string names of the form
        %'Block-XX'; numbers are positive integers greater than 0.
        %
        %Debugging Block name:
        %'Block-Receptive Field'
        BlockNames={};
        
        %Channel number being read from; requests for 0 channel result in
        %all channels being read.
        Channel=[];
        
        %Unit requested from channel; requests for 0 unit result in all
        %unit data being pulled.
        Unit=[];
        
        
        %% Characteristic Data
        %These parameters describe the experimental parameters used and are
        %associated with each trial.
        
        %Number of trials on requested set of experimental data.
        NTrials=[];
        
        %Epoc/variable codes generated by system.
        %
        %'swep' = trial number
        %'find' = casefile index
        %
        %'etyp' = electrical waveform type
        %'pgap' = electrical pulse waveform gap
        %'eamp' = electrical stimulus amplitude
        %
        %'s1ig' = Channel 1 stimulus type
        %'mdp1' = AM modulation depth percent
        %'mfr1' = AM modulation carrier frequency
        %'lev1' = Audio channel 1 sound intensity
        %'frq1' = Audio channel 1 tone frequency
        %
        %'s2ig' = Channel 2 stimulus type
        %'mdp2' = AM modulation depth percent
        %'mfr2' = AM modulation carrier frequency
        %'lev2' = Audio channel 2 sound intensity
        %'frq2' = Audio channel 2 tone frequency
        %
        %Above list is not complete and legacy versions of code contain
        %extra tags; as they are found please upgrade list.
        EpocNames=[];
        
        %Contains values, onset and offset timestamps for each epoc/variable
        Epocs = struct('Values',dataset,'TSOn',dataset,'TSOff',dataset);
        
        %Struct containing a reference between block number, casefile
        %number, and trial index from the start of the experiment.
        %         Indices = dataset([],[],[],'VarNames',{'Blocks','CaseFiles','Trials'})
        
        %Each struct contains a dataset with a row for each trial and a
        %column for each epoc/variable.
        %         FileDesc = dataset([],{},'VarNames',{'Block','CaseFileType'});
        
        
        %% Debugging and User Interface options
        
        %Enable debug print outs and timing checks for data requests.
        Debug=false;
        Timing=false;
        %
        %         %Any figures generated by routines will be shown to user.
        Graphics=true;
        
        %% Timestamp Data
        % This dataset contains the time stamp information provided by TDT
        % System 3, from the onset of the beginning of the trial. The
        % SortCodes are the various trial qualifiers provided by the TDT
        % system, including swep, s1ig, frq1, etc. BlockIdx sorts the
        % trials by block from the onset of the experiment. TrialIdx sorts
        % the trials by trial number from the onset of the experiment. The
        % various Raster times plot the onset and offset of the trial
        % relative to swep onset, the first sound stimulus on set, the
        % second sound stimulus onset, or the electrical stimulus onset.
        % The relative onset point can also be specified by the user during
        % construction.
        %
        % The user can also request sorted versus unsorted units by
        % changing the parameter 'SortCodeType'; the default is 'PLXSort'.
        % This tells the TDT server to find units that have been sorted by
        % the Plexon program.
        Spikes=dataset([],[],[],[],[],[],[],[],'VarNames', ...
            {'TS','SortCodes','BlockIdx','TrialIdx', ...
            'RasterSW','RasterS1','RasterS2','RasterE'});
        SortCodeType = 'none';
        
        
    end
    
    
    
    methods
        
        
        %% Instantiation and Data Collection Functions
        %This function initializes the object and collects data from the
        %required tank, blocks, channel and units
        
        
        
        
        function [obj, varargout] = superspiketrain(t,b,ch,un,varargin)
            % This function is the fundamental constructor for the spiketrain
            % object
            %
            % superspiketrain(tankname, blockname, channelnumber, unit, variable)
            %
            % Invalid parameters will cause failure to initialize properly
            
            
            %Enable calculation of execution time of parameters
            if find(strcmp(varargin,'timing'))
                obj.Timing = true;
                tstart = tic;
            end
            
            %Use of timing parameter to discover bottlenecks in code
            if obj.Timing; tic; end;
            
            %Enable debugging command line outputs
            if  find(strcmp(varargin,'debug'))
                obj.Debug=true;
            end
            
            %obj.Graphics = false;
            %Enable generation of figures from built in routines
            if  find(strcmp(varargin,'graphics'))
                obj.Graphics=true;
            end
            
            %Enable collection of timestamp data for input parameters as
            %well as accept legacy inputs requesting timestamps
            
            %             if (isa(varargin{1,1},'logical') && varargin{1,1})
            %                 varargin{1,1} = 'timestamps';
            %             end
            
            format long;
            
            %Allow user to specify which sorting code to use for units
            %             try
            %             if ismember('sortcode',varargin)
            %                 obj.SortCodeType = varargin{1+find(ismember(varargin,'sortcode'))};
            %             end
            %             catch
            %                   obj.SortCodeType = 'PLXSort';
            %             end
            
            %Read user input
            if (strcmp(t,'')) %% If no tank supplied, use default tank and block.
                % REMOVE DEFAULT TANK (CW EDIT)
                %                 obj.Tank = 'AOS004';
                error('Error: Please supply tank path');
            else
                obj.Tank=t;
            end
            
            %If no specific channels are requested, provide user with 0
            %channel. This tells TDT to provide all channnels in tank.
            if (isempty(ch))
                ch = 0;
            end
            %If no specific units are requested, provide user with 0 unit.
            %This tells TDT to provide all units on channel.
            if (isempty(un))
                un = 0;
            end
            
            if un==0
                obj.SortCodeType = 'none';
            else
                obj.SortCodeType = 'PLXSort';
            end
            
            %Assign input data to SST object
            obj.Channel=ch;
            obj.Unit=un;
            obj.Block=b;
            
            if obj.Timing; fprintf('Reading user input took %f seconds.\n',toc); tic; end;
            
            % Access tank and read blocknames inside that tank. If blocks
            % requested are empty, then SST will open all blocks in that
            % tank. Else, it tries to open the requested blocks.
            TT = obj.GetTank();
            if isempty(obj.Block)
                
                %TDT method query block name checks to see if block 'i'
                %exists. Function returns by numerical order according to
                %string index, ie 1 then 11 then 12 ... 19, 2, 21, 22, ...
                %Its dumb, we know.
                i=1; flag=TT.QueryBlockName(i);
                while flag
                    obj.BlockNames{i,1}=flag;
                    i=i+1;
                    flag=TT.QueryBlockName(i);
                end
                
                %Convert all 'Block-#' into numerical array of [#] and
                %uniquely sort in ascending order
                a=regexp(obj.BlockNames,'Block-','split');
                for i=1:length(a)
                    a{i}=str2num(a{i}{2}); %#ok<ST2NM>
                end
                a=cell2mat(a);
                [obj.Block,inds]=sort(a);
                obj.BlockNames=obj.BlockNames(inds);
                
            elseif isempty(obj.BlockNames)
                for k=1:length(obj.Block)
                    obj.BlockNames{k}=['Block-' num2str(obj.Block(k))];
                end
            end
            if obj.Timing; fprintf('Access tank and read blocknames took %f seconds.\n',toc); tic; end;
            
            %Read epoc names from all block
            
            EpocNames={};
            for k=1:length(obj.Block)
                TT=obj.GetBlock(TT,k);
                for i=1:20
                    EpocNames=[EpocNames;cellstr(TT.GetEpocCode(i-1))];
                end
            end
            obj.EpocNames=unique(EpocNames);
            obj.EpocNames(1)=[];
            if obj.Timing; fprintf('Read epoc names from first block took %f seconds.\n',toc); tic; end;
            
            %Read all epoc datasets
            clear i EpocNames;
            warning off; %#ok<*WNOFF>
            
            for k=1:length(obj.Block)
                TT=obj.GetBlock(TT,k);
                %%Read stimulus parameter values from stores
                Values=dataset; TSOn=dataset; TSOff=dataset;
                L=size(TT.GetEpocsExV('S1ig',0),2);
                for j=1:length(obj.EpocNames)
                    temp=TT.GetEpocsExV(obj.EpocNames{j},0);
                    if isnan(temp)
                        temp=NaN(4,L);
                    end
                    if strcmpi(obj.EpocNames(j),'Swep')
                        %Change Swep values from 0 referenced to 1
                        %referenced.  Plays better with matlab
                        temp(1,:)=temp(1,:)+1;
                    end
                    Values.(lower(obj.EpocNames{j}))=temp(1,:)';
                    TSOn.(lower(obj.EpocNames{j})) = temp(2,:)';
                    TSOff.(lower(obj.EpocNames{j})) = temp(3,:)';
                end
                
                Values=Values(1:L,:);
                TSOn=TSOn(1:L,:);
                TSOff=TSOff(1:L,:);
                
                Values=[mat2dataset(ones(L,1)*k,'varnames','bind'),Values];
                TSOn=[mat2dataset(TSOn.find,'varnames','bind'),TSOn];
                TSOff=[mat2dataset(TSOff.find,'varnames','bind'),TSOff];
                
                
                
                %Store data and accompanying characterizing data
                ValMerge{k.*2-1}=obj.Block(k);
                ValMerge{k.*2}=Values;
                OnMerge{k.*2-1}=obj.Block(k);
                OnMerge{k.*2}=TSOn;
                OffMerge{k.*2-1}=obj.Block(k);
                OffMerge{k.*2}=TSOff; %#ok<*AGROW>
            end
            if obj.Timing; fprintf('Read all epoc datasets took %f seconds.\n',toc); tic; end;
            
            %Merge epoc datasets for all trials then clear buffers to
            %prevent memory overload
            obj.EpocNames = lower(obj.EpocNames);
            obj.Epocs.Values=mergeDS({'Block'},ValMerge{:});
            clear Values ValMerge
            obj.Epocs.TSOn=mergeDS({'Block'},OnMerge{:});
            clear TSOn OnMerge
            obj.Epocs.TSOff=mergeDS({'Block'},OffMerge{:});
            clear TSOff OffMerge;
            
            obj.EpocNames=['bind';obj.EpocNames];
            
            obj.NTrials=length(obj.Epocs.Values(:,1));
            if obj.Timing; fprintf('Merge epoc datasets for all trials took %f seconds.\n',toc); tic; end;
            
            %%% Construct indicies for parsing data
            %Constructs a linearly increasing list for each trial in SST
            %             obj.Indices.Trials = cumsum(ones(obj.NTrials,1));
            
            %Constrcuts list associating trial number to block number. The
            %swep variable resets itself at the onset of each block then
            %increases linearly until the beginning of the new block.
            %Hence, the difference between swep should be not one whenever
            %a new block begins.
            %             obj.Indices.Blocks = cumsum(diff(obj.Epocs.Values.swep)~=1);
            %             obj.Indices.Blocks(end) = obj.Indices.Blocks(end-1);
            %             obj.Indices.Blocks = obj.Indices.Blocks + 1;
            
            %Try block handles legacy data for tanks that have a one to one
            %association between casefile and block number.
            %             try
            %                 %Constructs list of casefile indicies associating
            %                 %trialnumber to casefile. The cumulative difference of the
            %                 %sum of stored file index in a block plus the block number
            %                 %will result in a non zero value for all distinct file
            %                 %changes
            %                 obj.Indices.CaseFiles = cumsum(diff(obj.Epocs.Values.find + obj.Indices.Blocks) ~= 0);
            %                 obj.Indices.CaseFiles(end) = obj.Indices.CaseFiles(end-1);
            %                 obj.Indices.CaseFiles = obj.Indices.CaseFiles + 1;
            %             catch %#ok<CTCH>
            %                 obj.Indices.CaseFiles=obj.Indices.Blocks;
            %             end
            %             warning('on','all');
            
            if obj.Timing; fprintf('Construct indicies took %f seconds.\n',toc); tic; end;
            
            %%% Close tank Access
            obj.CloseTank(TT);
            
            if obj.Timing; fprintf('Close tank Access took %f seconds.\n',toc); tic; end;
            
            %Load timestamps at initialization if user requests them
            %CW EDIT: ALWAYS LOAD TIMESTAMPS
            %             if (find(strcmp(varargin,'timestamps')) || isa(varargin{1,1},'logical'))
            
            %Find out which kind of units the user wishes to read from
            obj = obj.LoadTS(0.0,0.0,obj.SortCodeType);
            if obj.Timing; fprintf('Load timestamps took %f seconds.\n',toc); tic; end;
            %             end
            
            %Load waveforms at initialization if user requests them
            if find(strcmp(varargin,'waveforms'))
                WaveData = [];
                SortCode = [];
                
                waveform_data = dataset({ones(1,33),'Channel','Block','SortNum','t1','t2','t3','t4','t5','t6','t7','t8','t9','t10','t11','t12','t13','t14','t15','t16','t17','t18','t19','t20','t21','t22','t23','t24','t25','t26','t27','t28','t29','t30'});
                
                for i=1:length(obj.Block)
                    % [WaveTemp, SortTemp] = LoadWV(obj, obj.Block(i));
                    [WaveTemp, SortTemp] = LoadWV(obj, i);
                    waves_derp = dataset({[ch.*ones(size(WaveTemp,2),1) b(i).*ones(size(WaveTemp,2),1) SortTemp WaveTemp'],'Channel','Block','SortNum','t1','t2','t3','t4','t5','t6','t7','t8','t9','t10','t11','t12','t13','t14','t15','t16','t17','t18','t19','t20','t21','t22','t23','t24','t25','t26','t27','t28','t29','t30'});
                    
                    waveform_data = cat(1,waveform_data,waves_derp);
                    %WaveData = [WaveData WaveTemp];
                    %SortCode = [SortCode SortTemp];
                    clear WaveTemp SortTemp;
                end
                %varargout{1,1} = WaveData;
                %varargout{1,2} = SortCode;
                waveform_data(1,:) = [];
                if obj.Timing; fprintf('Load waveforms took %f seconds.\n',toc); tic; end;
                clear WaveData SortCode;
                save([pwd '\WaveData_Ch_' num2str(ch) '.mat'],'waveform_data');
            end
            
            %Print out total time for entire initialization
            if obj.Timing; fprintf('Total execution time: %f.\n', toc(tstart)); end;
            
            obj.Summary;
            
            
            
        end
        
        %This function loads timestamps for object units
        function obj=LoadTS(obj,T1,T2,varargin)
            % LoadTimeStamps(T1,T2) reads spike timestamps from the tank into
            % matlab spiketrain object.  Spikes can be read from a particular time range in
            % the file given by T1 and T2. Default values of T1 = 0 and T2
            % = 0 results in all datavalues being read in.
            
            %%% Read user input
            datasnips = 1000000;
            
            %Establish empty row vectors for data
            obj.Spikes.TS=[];
            obj.Spikes.SortCodes=[];
            obj.Spikes.BlockIdx=[];
            obj.Spikes.TrialIdx=[];
            obj.Spikes.RasterSW=[];
            obj.Spikes.RasterS1=[];
            obj.Spikes.RasterS2=[];
            obj.Spikes.RasterE=[];
            
            %Set time windows to defaults unless times are specified
            if isempty(T1)
                T1=0.0;
            end
            if isempty(T2)
                T2=0.0;
            end
            
            
            % Request Tank Access
            if obj.Timing; tstart = tic; end;
            TT = obj.GetTank();
            if obj.Timing; fprintf('Tank Access took %f seconds.\n',toc); tic; end; %#ok<*UNRCH>
            
            
            %Read in timestamps for each block and merge
            warning off; %#ok<WNOFF>
            Last=0;
            for k=1:length(obj.Block)
                
                %Access Block Structure
                TT=obj.GetBlock(TT,k);
                
                % Set to read units with proper data filters.
                success=TT.SetUseSortName(obj.SortCodeType);
                if ~success&&obj.Debug; fprintf('---Failed SetUseSortname'); end;
                
                %                 filt = TT.SetFilterWithDescEx(['sort=' num2str(obj.Unit)]);
                TT.SetFilterWithDescEx(['sort=' num2str(obj.Unit)]);
                % Read in Spike Data. If N is greater than or equal to
                % datasnips then function must be recalled with a larger
                % value of datansips.
                
                %% DavidM: Fix this stupid bug
                %                 t_range = TT.GetValidTimeRangesV;
                %                 N = 0;
                %                 min_time = 0;
                %                 while N == 0 && min_time < max(t_range)
                N=TT.ReadEventsV(datasnips,'CSPK',obj.Channel,0,T1,T2,'FILTERED');
                %                      min_time = min_time + 1;
                %                 end
                %%
                
                obj.Spikes.TS(Last+1:Last+N,1) = TT.ParseEvInfoV(0, N, 6)';
                obj.Spikes.SortCodes(Last+1:Last+N,1) = TT.ParseEvInfoV(0, N, 5)';
                obj.Spikes.BlockIdx(Last+1:Last+N,1)=k;
                
                %Update position of index then print read time
                Last=Last+N;
                derp = ['Reading Spikes from Block-' num2str(k)];
                if obj.Timing; fprintf([derp ' took %f seconds.\n'],toc); tic; end; %#ok<UNRCH>
                
            end
            warning on; %#ok<WNON>
            obj.CloseTank(TT)
            if obj.Timing; fprintf(['Closing tank took %f seconds.\n'],toc); tic; end; %#ok<UNRCH>
            
            %%% Remove spikes from unit 0
            
            obj.Spikes(obj.Spikes.TS==0 & obj.Spikes.SortCodes==0,:)=[];
            try
                obj.Spikes(obj.Spikes.SortCodes~=obj.Unit,:)=[];
            end
            if obj.Timing; fprintf('Removal of bad spikes took %f seconds.\n',toc); tic; end;
            
            
            %%% Assign timestamps to trials
            % Loop through each timestamp, find which trial it belongs to
            % and subtract that swep timestamp
            TrialCode=zeros(length(obj.Spikes.TS),1);
            blocker = nominal(obj.Block);
            
            for j=1:length(obj.Block)
                
                %Determine off time in each trial for current block
                swepoff=obj.Epocs.TSOff.swep(ismember(obj.Epocs.TSOff.Block,blocker(j)));
                
                %Uses histogram counting function to seperate timestamp
                %data into bins
                try
                    [~,bins]=histc(obj.Spikes.TS(obj.Spikes.BlockIdx==j), ...
                        [obj.Epocs.TSOn.swep(ismember(obj.Epocs.TSOn.Block,blocker(j))); swepoff(end)]);
                    
                    %assign here the trial number that each spike belongs to
                    TrialCode(obj.Spikes.BlockIdx==j) = ...
                        bins+(bins~=0).*(find(ismember(obj.Epocs.Values.Block,blocker(j)),1)-1);
                catch   % GO BACK TO OLD STRATEGY WHEN 'HISTC' FAILS (CW EDIT)
                    for TrialCount=1:length(obj.Indices.Trials)
                        TrialCode( (obj.Spikes.BlockIdx==obj.Indices.Blocks(TrialCount))&((obj.Spikes.TS>obj.Epocs.TSOn.swep(TrialCount)) & ...
                            (obj.Spikes.TS<obj.Epocs.TSOff.swep(TrialCount))),1)=TrialCount;
                    end
                    
                end
            end
            if obj.Timing; fprintf('Spike-to-Trial calculation took %f seconds.\n',toc); tic; end;
            
            obj.Spikes.TrialIdx=TrialCode;
            obj.Spikes(TrialCode==0,:)=[];
            clear TrialCode blocker j;
            if obj.Timing; fprintf('Assign timestamp to trials took %f seconds.\n',toc); tic; end; %#ok<UNRCH>
            
            %%% Convert timestamps to rasters
            obj.Spikes.RasterSW=obj.Spikes.TS-obj.Epocs.TSOn.swep(obj.Spikes.TrialIdx);
            if ismember('s1ig',get(obj.Epocs.TSOn,'VarNames'))
                obj.Spikes.RasterS1=obj.Spikes.TS-obj.Epocs.TSOn.s1ig(obj.Spikes.TrialIdx);
            elseif ismember('s1on',get(obj.Epocs.TSOn,'VarNames'))
                obj.Spikes.RasterS1=obj.Spikes.TS-obj.Epocs.TSOn.s1on(obj.Spikes.TrialIdx);
            end
            if ismember('s2ig',get(obj.Epocs.TSOn,'VarNames'))
                obj.Spikes.RasterS2=obj.Spikes.TS-obj.Epocs.TSOn.s2ig(obj.Spikes.TrialIdx);
            elseif ismember('s2on',get(obj.Epocs.TSOn,'VarNames'))
                obj.Spikes.RasterS2=obj.Spikes.TS-obj.Epocs.TSOn.s2on(obj.Spikes.TrialIdx);
            end
            if ismember('etyp',get(obj.Epocs.TSOn,'VarNames'))
                obj.Spikes.RasterE=obj.Spikes.TS-obj.Epocs.TSOn.etyp(obj.Spikes.TrialIdx);
            end
            
            if obj.Timing; fprintf('Convert timestamps to rasters took %f seconds.\n',toc); fprintf('Loading timestamps took %f seconds.\n',toc(tstart)); end;
            
            nspikesloaded = size(obj.Spikes,1);
            if nspikesloaded == datasnips
                warning('N spikes may exceed pre-defined value. Change DATASNIPS value in SUPERSPIKETRAIN and reload.');
            end
            
        end
        
        %This function loads waveforms for object units
        function [WaveData SortCode] = LoadWV(obj, block)
            % This function prints off waveforms from the requested block
            % for the unit associated with the superspiketrain object. It
            % also provides the accompanying sort codes for the indicated
            % waveforms.
            TT = GetTank(obj);
            
            TT = obj.GetBlock(TT,block);
            success = TT.SetUseSortName(obj.SortCodeType);
            
            if ~success&&obj.Debug; fprintf('---Failed SetUseSortname'); end;
            
            TT.SetFilterWithDescEx(['sort=' num2str(obj.Unit)]);
            N=TT.ReadEventsV(100000,'CSPK',obj.Channel,0,0.0, 0.0,'FILTERED');
            SortCode = double(TT.ParseEvInfoV(0, N, 5)');
            WaveData = double(TT.ParseEvV(0,N));
            
            %             if obj.Graphics
            %                 figure()
            %                 mesh(double(WaveData))
            %             end
            CloseTank(obj,TT);
            clear TT;
            
        end
        
        %%Summary of aggregate data
        function Summary(obj)
            % Prints off major data about the spiketrain structure
            tanker = char(obj.Tank);
            %             fprintf(['Spike train from Unit: ' num2str(obj.Unit) ' of Channel ' num2str(obj.Channel) ' of %s.\n'],tanker)
            %             fprintf([num2str(obj.Channel) '-' num2str(obj.Unit) '.. '])
        end
        
        
        
        
        %% TDT Tank Interface Functions
        % When using the tank and server interfaces, care must be taken to
        % ensure that connections are not established and left open. Proper
        % access follows this protocol:
        %
        %1) Establish connection to server
        %2) Establish connection to tank
        %3) Establish connection to 1 block and create associated epoc
        %   indexing
        %4) Use Data
        %5) Close connection to tank
        %6) Close connection to server
        %7) Ensure that residual objects associated with server are
        %   destroyed
        %
        % The following functions establish this protocol: GetTank,
        % GetBlock, and CloseTank. GetTank will provide user with a server
        % and tank handle that must be passed around when using futher tank
        % access functions. After CloseTank is called, use 'clear [handle]'
        % immediately to ensure proper closure of tank and server.
        function [TT] = GetTank(obj)
            % This function enables access to a TDT tank structure to read
            % in data. Returns a handle to the requested tank if
            % successful, otherwise prints failure cause.
            %
            % See 'OpenDeveloper_Manual.pdf' for more details and command
            % options available for tank and server structure. See
            % superspiketrain documentation under 'TDT Tank Interface
            % Functions' for proper use of TDT access protocol.
            
            
            % Initialize access to TTank server. Print errors in case of
            % failure or if debugging.
            TT=actxserver('TTank.X');
            success=TT.ConnectServer('Local','Me');
            if ~success
                if obj.Debug; fprintf('Connect failed.\n'); end;
                TT.GetError;
                return;
            elseif success
                if obj.Debug; fprintf('-Connected to Local server.\n'); end;
            end
            
            success = TT.OpenTank(obj.Tank,'R');
            if ~success;
                
                TT.ResetTank(obj.Tank);
                
                success=TT.OpenTank(obj.Tank,'R');
                if ~success
                    if obj.Debug; fprintf('--Open tank failed.\n'); end;
                    TT.GetError
                    return;
                elseif success;
                    if obj.Debug; fprintf('--Opened tank: %s.\n',obj.Tank); end;
                end
                
            elseif success;
                if obj.Debug; fprintf('--Opened tank: %s.\n',obj.Tank); end;
            end
        end
        
        %This function establishes connection to requested block
        function [TT] = GetBlock(obj,TT,i)
            %Gives access to requested block number. Proper use of this
            %function requires a previous call to GetTank() and the handle
            %associated with the current tank and server call.
            
            success=TT.SelectBlock(obj.BlockNames{i});
            if ~success;
                if obj.Debug; fprintf(['---Select block failed first attempt: ' obj.BlockNames{i} '.\n']); end;
                obj.CloseTank(TT); clear TT;% Close tank and try again.
                pause(0.25);
                
                %REMOVE GREG DEFULT (CW EDIT)
                %                 try
                %                 cd('R:\');
                %                 catch
                %                     cd('\\khri-sand.adsroot.itcs.umich.edu\GJB\2Data\AOSData');
                %                 end
                TT=obj.GetTank;
                success=TT.SelectBlock(obj.BlockNames{i});
                if ~success
                    if obj.Debug; fprintf(['---Select block failed 2nd attempt: ' obj.BlockNames{i} '.\n']);  TT.GetError
                    end;
                    return;
                    
                elseif success
                    if obj.Debug; fprintf('---Selected %s after first error.\n',obj.BlockNames{i}); end
                end
            elseif success;
                if obj.Debug; fprintf('---Selected %s.\n',obj.BlockNames{i}); end;
            end
            
            success=TT.CreateEpocIndexing;
            if ~success;
                if obj.Debug; fprintf('---Create Epoc Indexing failed.\n'); TT.GetError; end;
                return;
            elseif success;
                if obj.Debug; fprintf('---Created Epoc Indexing for %s.\n',obj.BlockNames{i}); end;
            end
        end
        
        %%This function closes connection to indicated tank object
        function CloseTank(obj,TT)
            % Releases access from a TDT tank structure.
            TT.CloseTank;
            if obj.Debug;
                fprintf('--Closed tank: %s.\n',obj.Tank);
            end
            TT.ReleaseServer;
            if obj.Debug;
                fprintf('-Released Local server.\n');
            end
            TT.delete;
            clear TT;
        end
        
        
        
        %% Fundamental Paradigm for accessing spike data
        
        %Generate a unique sorted list of numerical values associated with
        %the requested epoc
        function [Output] = SortedEpocs(obj,EpocType,varargin)
            
            if ~isfield(obj,'tind')
                output = 1;
            end
            if isempty(varargin)
                Output=unique(obj.Epocs.Values.(EpocType));
            else
                trials=varargin{1};
                Output=unique(obj.Epocs.Values.(EpocType)(trials));
            end
            
        end
        
        %Returns the timestamps associated with the requested list of
        %trials
        function [Spikes] = GetSpikes(obj,trials,rastertype)
            % [Spikes]=GetSpikes(obj,trials,rastertype) returns the time stamps
            % for the requested set of trials and raster.
            %
            % Use of TrialSelect is highly encouraged for generation of a list
            % of trials according to stimulus parameters used in experiments.
            
            
            if ismember('tind',obj.Epocs.Values.Properties.VarNames) % sst_multi => fix, otherwise disregard
                if min(diff(obj.Spikes.TrialIdx))<0 % if already fixed, disregard
                    [~,sep] = unique(obj.Spikes.TankIdx);
                    sep=[sep;length(obj.Spikes.TankIdx)+1];
                    for i=2:length(sep)-1
                        tank_n = obj.Spikes.TankIdx(sep(i));
                        trial_prev = max(find(obj.Epocs.Values.tind==(tank_n-1)));
                        
                        obj.Spikes.TrialIdx(sep(i):sep(i+1)-1) = obj.Spikes.TrialIdx(sep(i):sep(i+1)-1) + trial_prev;
                    end
                end
            end
            
            
            Spikes=obj.Spikes.(['Raster' rastertype])(ismember(obj.Spikes.TrialIdx,trials));
            
            
        end
        
        %Returns a list of trials having the requested parameters
        function [trials]=TrialSelect(obj,varargin) %#ok<STOUT>
            % Generates a unique list of trials corresponding to requested
            % stimulus parameters. Requested parameters act as a logical
            % AND.
            %
            % These values should be as follows: 'Block',[1 3 5],'Lev1',[0 5
            % 10],'Frq1',[1000 2000],... All
            %
            % When called without inputs, function returns a list of all
            % trials available to the superspiketrain object.
            %
            % Use this function in conjunction with SortedEpocs and
            % GetSpikes for maximally efficient data sorting.
            
            if isempty(varargin)
                %                stats = grpstats(obj.Epocs.Values,obj.EpocNames,{'numel'});
                %                varargout{:,:} = stats(:,1:1+length(obj.EpocNames()));
                trials = 1:obj.NTrials;
                return;
            end
            
            warning off; %#ok<WNOFF>
            Parameter=varargin(1:2:end);
            Value=varargin(2:2:end);
            for j=1:length(Parameter)
                In.(lower(Parameter{j}))=Value{j};
            end
            warning on; %#ok<WNON>
            
            if ~ismember('tind',obj.EpocNames)&isfield(In,'tind')
                In=rmfield(In,'tind');
            end
            
            EpocNamesL=fieldnames(In);
            findList=[];
            
            for i = 1:length(EpocNamesL)
                findList=[findList; find(ismember(obj.Epocs.Values.(EpocNamesL{i}),In.(EpocNamesL{i})) ) ];
            end
            findCount=hist(findList,1:1:obj.NTrials);
            trials=find(findCount==length(EpocNamesL));
            
            if isempty(trials)
                trials=nan;
            end
            
            
            
        end
        %%
        
        
        
        %% Repeatedly used functions that use spiketrain Fundamental Paradigm functions
        % The following functions are examples of how the fundamental data
        % access paradigm can be used to generate relevant data from an
        % experiment.
        
        
        %%Calculate requested spike rate(s) for indicated variables
        function [Rate] = SpikeRate(obj,Window,trials,varargin)
            % SpikeRate([T1 T2],obj.TrialSelect('Lev1',[..],'Frq1',[..],..)
            % SpikeRate([T1 T2],obj.TrialSelect(..),'type','S1'/'S2'
            % 'type'    - 'SW','S1','S2', 'E', or a reference time
            %           'SW' - trial sweep, 'S1' - Stim 1 onset, 'S2' - stim
            %           2 onset, 'E' - electrical stim onset, or a reference
            %           time within the trial window.
            % 'out'     - 'all' or 'trials'
            % 'norm'    - 'count'   - raw spike counts
            %           or 'trial' - counts of spikes per trial
            %           or 'rate' - spikes per second
            % This function calculates the spike rate for each trial
            % requested over the indicated time window for the selected set
            % of trial parameters indicated. T1 and T2 must be contained in
            % the time window indicated by the selected raster time frame.
            % This function defaults to time calculations based upon the
            % onset of the channel one auditory stimulus. NOTE: This
            % algorithm is slow for returning individual trial rates for
            % many trials.
            
            %If there are no spikes for this data, return with nan and
            %print warning.
            if isempty(obj.Spikes)
                %                 fprintf('Please get spike data\n')
                Rate=nan;
                return;
            end
            
            %If no trials are requested, then use all unique trials. If no
            %trials are present, return with nan.
            if isempty(trials)
                trials=unique(obj.TrialSelect());
            elseif isnan(trials)
                Rate=nan;
                return;
            end
            
            %Sort input data into parsable struct
            Parameter=varargin(1:2:end);
            Value=varargin(2:2:end);
            for j=1:length(Parameter)
                In.(lower(Parameter{j}))=Value{j};
            end
            
            %Detect for legacy system parameters.
            if ismember('s1ig',obj.EpocNames)
                In.legacy=false;
            else
                In.legacy=true;
            end
            
            %Detect to see which raster time user requests; default to
            %onset of first auditory channel stimulus. Calculate time
            %reference when specified.
            if ~isfield(In,'type')
                In.type='S1';
                if In.legacy
                    In.reftime=obj.Epocs.TSOn.s1on(1)-obj.Epocs.TSOn.swep(1);
                else
                    In.reftime=obj.Epocs.TSOn.s1ig(1)-obj.Epocs.TSOn.swep(1);
                end
            else
                if isa(In.type,'string')
                    In.type=upper(In.type);
                    switch In.type
                        case 'SW'; if In.legacy; In.reftime=obj.Epocs.TSOn.swep(1); else In.reftime=obj.Epocs.TSOn.swep(1); end;
                        case 'S1'; if In.legacy; In.reftime=obj.Epocs.TSOn.s1on(1); else In.reftime=obj.Epocs.TSOn.s1ig(1); end;
                        case 'S2'; if In.legacy; In.reftime=obj.Epocs.TSOn.s2on(1); else In.reftime=obj.Epocs.TSOn.s2ig(1); end;
                        case 'E';  if In.legacy; In.reftime=0.025+obj.Epocs.TSOn.swep(1); else In.reftime=obj.Epocs.TSOn.etyp(1); end;
                    end
                    In.reftime=In.reftime-obj.Epocs.TSOn.swep(1);
                else
                    In.reftime=In.type;
                end
            end;
            
            if ~isfield(In,'out') % Error check input: Default to all if not selected or incorrect input.
                In.out='all';
            elseif ~ismember(In.out,{'all' 'trials'})
                In.out='all';
            end
            
            if ~isfield(In,'norm') % Error check input: Default to rates;
                In.norm='rate';
            end
            
            % If the user supplies a reftime as a double input to In.type, then create a new raster type
            % using that reftime
            if isa(In.type,'double')
                obj.Spikes.RasterTemp = obj.Spikes.RasterSW-In.type;
                In.type='Temp';
            end
            
            %Calculate rate for each trial requested or calculate average
            %rate on all trials
            if ismember(In.out,{'trials'})
                Rate = zeros(1,length(trials));
                switch In.norm % Set norm factor
                    case 'rate'; normfactor=Window(2)-Window(1);
                    case 'trial'; normfactor=1;
                    case 'count'; normfactor=1;
                end
                
                %Calculate rate for each trial
                for i=1:length(trials)
                    
                    %Get timestamps for the specific trial
                    LocalSpikes=obj.GetSpikes(trials(i),In.type);
                    
                    %Calculate rate for indicated trial
                    Rate(i) = length(LocalSpikes(((LocalSpikes >= Window(1)) & (LocalSpikes <= Window(2)))))/normfactor;
                    clear LocalSpikes
                end
            else
                LocalSpikes =  obj.GetSpikes(trials,In.type);
                switch In.norm % Set norm factor
                    case 'rate'; normfactor=length(trials).*(Window(2)-Window(1));
                    case 'trial'; normfactor=length(trials);
                    case 'count'; normfactor=1;
                end
                Rate = length(LocalSpikes(((LocalSpikes >= Window(1)) & (LocalSpikes <= Window(2))))) / normfactor;
            end
            
        end
        
        
        %%Spike intenisty plotter
        function [data x y ah] = SpikeIntensity(obj,EpocType1,EpocType2)
            % ReceptiveField('Xvariable','Yvariable') plots a 2-d grid plot
            % of spike intensities as they depend on the variables chosen.
            % Typically this is used to create a receptive field of
            % intensity versus frequency for a given channel's worth of
            % datata. This function also returns the calculated data in an
            % x by y grid, the grid values and the plot handle.
            
            %             load('Z:\3Shared\Matlab Scripts\Superspiketrain\RFColorMap.mat');
            x = obj.SortedEpocs(EpocType1);
            y = obj.SortedEpocs(EpocType2);
            
            for i = 1:length(x)
                for j = 1:length(y)
                    data(j,i) = length(obj.GetSpikes(obj.TrialSelect(EpocType1,x(i),EpocType2,y(j)),'SW'));  %#ok<AGROW>
                end
            end
            
            ah = 0;
            
            if (obj.Graphics)
                figure()
                ah = pcolor(x,y,data);
                colormap;
                axis([min(x) max(x) min(y) max(y)]);
            end
        end
        
        
        %%Construct Raster Plot of Data
        function [data ah]=RASTERPLOT(obj,trials,varargin)
            % This function creates a Raster plot of spike data for the
            % indicated input trials. In addition, the reference for the
            % raster 'type'- 'SW','S1','S2', 'E', or a reference time
            %          'SW' - trial sweep, 'S1' - Stim 1 onset, 'S2' - stim
            %          2 onset, 'E' - electrical stim onset, or a reference
            %          time within the trial window.
            % 'window'- [W1 W2] where these are the times relative to the
            %           reference time of the beginning and end times of
            %           the trial display window.
            % 'ah'    - A new figure is created if not specified by the
            %         user with 'ah'
            if isempty(obj.Spikes)
                fprintf('Please get spike data\n')
                return;
            end
            
            if isempty(trials)
                trials=unique(obj.TrialSelect());
            elseif isnan(trials)
                fprintf('No trials to run RASTER on.\n');
                return;
            end
            
            In = varargin;
            
            Parameter=varargin(1:2:end);
            Value=varargin(2:2:end);
            for j=1:length(Parameter)
                In.(lower(Parameter{j}))=Value{j};
            end
            
            if ismember('s1ig',obj.EpocNames)
                In.legacy=false;
            else
                In.legacy=true;
            end
            
            if ~isfield(In,'type')
                In.type='S1';
                if In.legacy
                    In.reftime=obj.Epocs.TSOn.s1on(1)-obj.Epocs.TSOn.swep(1);
                else
                    In.reftime=obj.Epocs.TSOn.s1ig(1)-obj.Epocs.TSOn.swep(1);
                end
            else
                if isa(In.type,'string')
                    In.type=upper(In.type);
                    switch In.type
                        case 'SW'; if In.legacy; In.reftime=obj.Epocs.TSOn.swep(1); else In.reftime=obj.Epocs.TSOn.swep(1); end;
                        case 'S1'; if In.legacy; In.reftime=obj.Epocs.TSOn.s1on(1); else In.reftime=obj.Epocs.TSOn.s1ig(1); end;
                        case 'S2'; if In.legacy; In.reftime=obj.Epocs.TSOn.s2on(1); else In.reftime=obj.Epocs.TSOn.s2ig(1); end;
                        case 'E';  if In.legacy; In.reftime=0.025+obj.Epocs.TSOn.swep(1); else In.reftime=obj.Epocs.TSOn.etyp(1); end;
                    end
                    In.reftime=In.reftime-obj.Epocs.TSOn.swep(1);
                else
                    In.reftime=In.type;
                end
            end;
            
            if ~isfield(In,'time')
                triallength=obj.Epocs.TSOff.swep(trials(1))-obj.Epocs.TSOn.swep(trials(1));
                In.time=[0 triallength] -In.reftime;
            end
            
            if ~isfield(In,'ah')
                In.fh=figure;
                clf(In.fh);
                In.ah=axes();
            end
            ah=In.ah;
            
            % If the user supplies a reftime as a double input to In.type, then create a new raster type
            % using that reftime
            if isa(In.type,'double')
                obj.Spikes.RasterTemp = obj.Spikes.RasterSW-In.type;
                In.type='Temp';
            end
            
            LocalSpikes=obj.GetSpikes(trials,In.type);
            dataIndicies = obj.Spikes.TrialIdx(ismember(obj.Spikes.TrialIdx,trials));
            data = obj.Epocs.Values.lev1(dataIndicies);
            
            if ~isfield(In,'window')
                tstart=In.time(1);% min(LocalSpikes);
                tend=In.time(2);%max(LocalSpikes);
            else
                tstart=In.window(1);
                tend=In.window(2);
            end
            
            plot(LocalSpikes,dataIndicies,'.','MarkerSize',10)
            axis([tstart tend 0 max(dataIndicies)])
            
            title({['Raster Plot from channel ' num2str(obj.Channel) ', Unit ' num2str(obj.Unit) '.'];['Raster Type: ',In.type]})
            xlabel('Raster time (sec)')
            ylabel('Trial')
            grid
        end
        
        
        %%Construct PSTH Plot of Data
        function [pData bins ah]=PSTH(obj,trials,varargin)
            % [pData bins ah] = SST.PSTH(trials[,'Parameter',Value])
            % Plot PSTH in two different modes
            % raster 'type'- 'SW','S1','S2', 'E', or a reference time
            %          'SW' - trial sweep, 'S1' - Stim 1 onset, 'S2' - stim
            %          2 onset, 'E' - electrical stim onset, or a reference
            %          time within the trial window.
            % 'window'- [W1 W2] where these are the times relative to the
            %           reference time of the beginning and end times of
            %           the trial display window.
            % 'bw' - single value
            % 'ah' - single value containing axis handle.
            % 'norm' - 'count' or 'trial' or 'rate'
            % 'line' - {'linespec','param1','value1', ...}
            % 'bar' - {'linespec','param1','value1',...}
            % Trials is a vector array of a list of trials to include in
            % the PSTH analysis
            
            % Ask for counts, rates or trial average
            
            if isempty(obj.Spikes)
                fprintf('Please get spike data.\n')
                return;
            end
            
            if isempty(trials)
                trials=unique(obj.TrialSelect());
            elseif isnan(trials)
                fprintf('No trials to run PSTH on.\n');
                return;
            end
            
            In = varargin;
            
            if ismember('s1ig',obj.EpocNames)
                In.legacy=false;
            else
                In.legacy=true;
            end
            
            Parameter=varargin(1:2:end);
            Value=varargin(2:2:end);
            for j=1:length(Parameter)
                In.(lower(Parameter{j}))=Value{j};
            end
            
            if ~isfield(In,'type')
                In.type='S1';
                if In.legacy
                    In.reftime=obj.Epocs.TSOn.s1on(1)-obj.Epocs.TSOn.swep(1);
                else
                    In.reftime=obj.Epocs.TSOn.s1ig(1)-obj.Epocs.TSOn.swep(1);
                end
            else
                if isa(In.type,'string')
                    In.type=upper(In.type);
                    switch In.type
                        case 'SW'; if In.legacy; In.reftime=obj.Epocs.TSOn.swep(1); else In.reftime=obj.Epocs.TSOn.swep(1); end;
                        case 'S1'; if In.legacy; In.reftime=obj.Epocs.TSOn.s1on(1); else In.reftime=obj.Epocs.TSOn.s1ig(1); end;
                        case 'S2'; if In.legacy; In.reftime=obj.Epocs.TSOn.s2on(1); else In.reftime=obj.Epocs.TSOn.s2ig(1); end;
                        case 'E';  if In.legacy; In.reftime=0.025+obj.Epocs.TSOn.swep(1); else In.reftime=obj.Epocs.TSOn.etyp(1); end;
                    end
                    In.reftime=In.reftime-obj.Epocs.TSOn.swep(1);
                else
                    In.reftime=In.type;
                end
            end;
            
            if ~isfield(In,'time')
                triallength=obj.Epocs.TSOff.swep(trials(1))-obj.Epocs.TSOn.swep(trials(1));
                In.time=[0 triallength] - In.reftime;
            end
            
            
            if ~isfield(In,'ah')
                In.fh=figure;
                clf(In.fh);
                In.ah=axes();
            end
            ah=In.ah;
            
            % If the user supplies a reftime as a double input to In.type, then create a new raster type
            % using that reftime
            if isa(In.type,'double')
                obj.Spikes.RasterTemp = obj.Spikes.RasterSW-In.type;
                In.type='Temp';
            end
            
            if ~isfield(In,'bw')
                In.bw=0.001;
            end
            
            if ~isfield(In,'norm')
                In.norm='rate';
            end
            
            if ~isfield(In,'line')
                In.line={};
            end
            
            if ~isfield(In,'bar')
                In.bar={'k'};
            end
            
            LocalSpikes = obj.GetSpikes(trials, In.type);
            
            if ~isfield(In,'window')
                tstart=In.time(1);% min(LocalSpikes);
                tend=In.time(2);%max(LocalSpikes);
            else
                tstart=In.window(1);
                tend=In.window(2);
            end
            bins=tstart:In.bw:tend;
            
            if strcmp(In.norm,'count')
                pData=histc(LocalSpikes,bins);
                ytext='Spike Counts';
            elseif strcmp(In.norm,'trial')
                pData = histc(LocalSpikes,bins)./(length(trials));
                ytext='Spike Rate [sp/trial]';
            elseif strcmp(In.norm,'rate')
                pData = histc(LocalSpikes,bins)./(length(trials).*In.bw);
                ytext='Spike Rate [sp/sec]';
            else
                In.norm='rate';
                pData = histc(LocalSpikes,bins)./(length(trials).*In.bw);
                ytext='Spike Rate [sp/sec]';
            end
            
            if obj.Graphics
                if isempty(In.line)
                    bar(ah,bins+.5.*In.bw,pData,1,In.bar{:});
                else
                    plot(ah,bins+0.5.*In.bw,pData,In.line{:});
                end
                
                title({['PSTH from Tank ' obj.Tank ', Channel ' num2str(obj.Channel) ', Unit ' num2str(obj.Unit) '.'];['Blocks ' num2str(obj.Block)];['Raster Time: ',In.type]})
                xlabel('Raster Time [sec]')
                ylabel(ytext)
                xlim(ah,[tstart tend]);
                ycurrent=ylim(ah);
                ylim(ah,[0 max(1.1.*max(pData),ycurrent(2))])
                
                
                grid
            end
        end
        
        
    end
end






