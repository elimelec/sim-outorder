sim-outorder: SimpleScalar/PISA Tool Set version 3.0 of November, 2000.
Copyright (c) 1994-2000 by Todd M. Austin.  All Rights Reserved.
This version of SimpleScalar is licensed for academic non-commercial use only.

sim: command line: ./sim-outorder -redir:sim gemhSim.res -redir:prog gemhProg.res -max:inst 10000000 -fetch:ifqsize 4 -fetch:mplat 3 -decode:width 4 -issue:width 4 -issue:inorder False -issue:wrongpath True -ruu:size 16 -lsq:size 8 -res:ialu 4 -res:imult 1 -res:memport 2 -res:fpalu 4 -res:fpmult 1 -cache:dl1lat 1 -mem:width 1024 -tlb:lat 256 -bpred:bimod 2048 -bpred:2lev 1 1024 8 0 -bpred:btb 512 4 -cache:dl1 dl1:256:32:1:l -cache:dl2 dl2:256:32:1:l -cache:il1 il1:256:32:1:l -cache:il2 il2:256:32:1:l -tlb:dtlb dtlb:32:4096:4:l -tlb:itlb itlb:16:4096:4:l -cache:flush False -cache:icompress False applu.ss 

sim: simulation started @ Sat Apr  9 13:23:20 2016, options follow:

sim-outorder: This simulator implements a very detailed out-of-order issue
superscalar processor with a two-level memory system and speculative
execution support.  This simulator is a performance simulator, tracking the
latency of all pipeline operations.

# -config                     # load configuration from a file
# -dumpconfig                 # dump configuration to a file
# -h                    false # print help message    
# -v                    false # verbose operation     
# -d                    false # enable debug message  
# -i                    false # start in Dlite debugger
-seed                       1 # random number generator seed (0 for timer seed)
# -q                    false # initialize and terminate immediately
# -chkpt               <null> # restore EIO trace execution from <fname>
# -redir:sim      gemhSim.res # redirect simulator output to file (non-interactive only)
# -redir:prog    gemhProg.res # redirect simulated program output to file
-nice                       0 # simulator scheduling priority
-max:inst            10000000 # maximum number of inst's to execute
-fastfwd                    0 # number of insts skipped before timing starts
# -ptrace              <null> # generate pipetrace, i.e., <fname|stdout|stderr> <range>
-fetch:ifqsize              4 # instruction fetch queue size (in insts)
-fetch:mplat                3 # extra branch mis-prediction latency
-fetch:speed                1 # speed of front-end of machine relative to execution core
-bpred                  bimod # branch predictor type {nottaken|taken|perfect|bimod|2lev|comb}
-bpred:bimod     2048 # bimodal predictor config (<table size>)
-bpred:2lev      1 1024 8 0 # 2-level predictor config (<l1size> <l2size> <hist_size> <xor>)
-bpred:comb      1024 # combining predictor config (<meta_table_size>)
-bpred:ras                  8 # return address stack size (0 for no return stack)
-bpred:btb       512 4 # BTB config (<num_sets> <associativity>)
# -bpred:spec_update       <null> # speculative predictors update in {ID|WB} (default non-spec)
-decode:width               4 # instruction decode B/W (insts/cycle)
-issue:width                4 # instruction issue B/W (insts/cycle)
-issue:inorder          false # run pipeline with in-order issue
-issue:wrongpath         true # issue instructions down wrong execution paths
-commit:width               4 # instruction commit B/W (insts/cycle)
-ruu:size                  16 # register update unit (RUU) size
-lsq:size                   8 # load/store queue (LSQ) size
-cache:dl1       dl1:256:32:1:l # l1 data cache config, i.e., {<config>|none}
-cache:dl1lat               1 # l1 data cache hit latency (in cycles)
-cache:dl2       dl2:256:32:1:l # l2 data cache config, i.e., {<config>|none}
-cache:dl2lat               6 # l2 data cache hit latency (in cycles)
-cache:il1       il1:256:32:1:l # l1 inst cache config, i.e., {<config>|dl1|dl2|none}
-cache:il1lat               1 # l1 instruction cache hit latency (in cycles)
-cache:il2       il2:256:32:1:l # l2 instruction cache config, i.e., {<config>|dl2|none}
-cache:il2lat               6 # l2 instruction cache hit latency (in cycles)
-cache:flush            false # flush caches on system calls
-cache:icompress        false # convert 64-bit inst addresses to 32-bit inst equivalents
-mem:lat         18 2 # memory access latency (<first_chunk> <inter_chunk>)
-mem:width               1024 # memory access bus width (in bytes)
-tlb:itlb        itlb:16:4096:4:l # instruction TLB config, i.e., {<config>|none}
-tlb:dtlb        dtlb:32:4096:4:l # data TLB config, i.e., {<config>|none}
-tlb:lat                  256 # inst/data TLB miss latency (in cycles)
-res:ialu                   4 # total number of integer ALU's available
-res:imult                  1 # total number of integer multiplier/dividers available
-res:memport                2 # total number of memory system ports available (to CPU)
-res:fpalu                  4 # total number of floating point ALU's available
-res:fpmult                 1 # total number of floating point multiplier/dividers available
# -pcstat              <null> # profile stat(s) against text addr's (mult uses ok)
-bugcompat              false # operate in backward-compatible bugs mode (for testing only)

  Pipetrace range arguments are formatted as follows:

    {{@|#}<start>}:{{@|#|+}<end>}

  Both ends of the range are optional, if neither are specified, the entire
  execution is traced.  Ranges that start with a `@' designate an address
  range to be traced, those that start with an `#' designate a cycle count
  range.  All other range values represent an instruction count range.  The
  second argument, if specified with a `+', indicates a value relative
  to the first argument, e.g., 1000:+100 == 1000:1100.  Program symbols may
  be used in all contexts.

    Examples:   -ptrace FOO.trc #0:#1000
                -ptrace BAR.trc @2000:
                -ptrace BLAH.trc :1500
                -ptrace UXXE.trc :
                -ptrace FOOBAR.trc @main:+278

  Branch predictor configuration examples for 2-level predictor:
    Configurations:   N, M, W, X
      N   # entries in first level (# of shift register(s))
      W   width of shift register(s)
      M   # entries in 2nd level (# of counters, or other FSM)
      X   (yes-1/no-0) xor history and address for 2nd level index
    Sample predictors:
      GAg     : 1, W, 2^W, 0
      GAp     : 1, W, M (M > 2^W), 0
      PAg     : N, W, 2^W, 0
      PAp     : N, W, M (M == 2^(N+W)), 0
      gshare  : 1, W, 2^W, 1
  Predictor `comb' combines a bimodal and a 2-level predictor.

  The cache config parameter <config> has the following format:

    <name>:<nsets>:<bsize>:<assoc>:<repl>

    <name>   - name of the cache being defined
    <nsets>  - number of sets in the cache
    <bsize>  - block size of the cache
    <assoc>  - associativity of the cache
    <repl>   - block replacement strategy, 'l'-LRU, 'f'-FIFO, 'r'-random

    Examples:   -cache:dl1 dl1:4096:32:1:l
                -dtlb dtlb:128:4096:32:r

  Cache levels can be unified by pointing a level of the instruction cache
  hierarchy at the data cache hiearchy using the "dl1" and "dl2" cache
  configuration arguments.  Most sensible combinations are supported, e.g.,

    A unified l2 cache (il2 is pointed at dl2):
      -cache:il1 il1:128:64:1:l -cache:il2 dl2
      -cache:dl1 dl1:256:32:1:l -cache:dl2 ul2:1024:64:2:l

    Or, a fully unified cache hierarchy (il1 pointed at dl1):
      -cache:il1 dl1
      -cache:dl1 ul1:256:32:1:l -cache:dl2 ul2:1024:64:2:l



sim: ** starting performance simulation **
warning: syscall: sigvec ignored
warning: syscall: sigvec ignored
warning: syscall: sigvec ignored
warning: syscall: sigvec ignored
warning: syscall: sigvec ignored
warning: syscall: sigvec ignored

sim: ** simulation statistics **
sim_num_insn               10000000 # total number of instructions committed
sim_num_refs                1511224 # total number of loads and stores committed
sim_num_loads               1344584 # total number of loads committed
sim_num_stores          166640.0000 # total number of stores committed
sim_num_branches             170112 # total number of branches committed
sim_elapsed_time                  5 # total simulation time in seconds
sim_inst_rate          2000000.0000 # simulation speed (in insts/sec)
sim_total_insn             10013777 # total number of instructions executed
sim_total_refs              1519076 # total number of loads and stores executed
sim_total_loads             1352165 # total number of loads executed
sim_total_stores        166911.0000 # total number of stores executed
sim_total_branches           170585 # total number of branches executed
sim_cycle                   8409528 # total simulation time in cycles
sim_IPC                      1.1891 # instructions per cycle
sim_CPI                      0.8410 # cycles per instruction
sim_exec_BW                  1.1908 # total instructions (mis-spec + committed) per cycle
sim_IPB                     58.7848 # instruction per branch
IFQ_count                  28994774 # cumulative IFQ occupancy
IFQ_fcount                  7200120 # cumulative IFQ full count
ifq_occupancy                3.4478 # avg IFQ occupancy (insn's)
ifq_rate                     1.1908 # avg IFQ dispatch rate (insn/cycle)
ifq_latency                  2.8955 # avg IFQ occupant latency (cycle's)
ifq_full                     0.8562 # fraction of time (cycle's) IFQ was full
RUU_count                 117504827 # cumulative RUU occupancy
RUU_fcount                  7123597 # cumulative RUU full count
ruu_occupancy               13.9728 # avg RUU occupancy (insn's)
ruu_rate                     1.1908 # avg RUU dispatch rate (insn/cycle)
ruu_latency                 11.7343 # avg RUU occupant latency (cycle's)
ruu_full                     0.8471 # fraction of time (cycle's) RUU was full
LSQ_count                  16035883 # cumulative LSQ occupancy
LSQ_fcount                   199163 # cumulative LSQ full count
lsq_occupancy                1.9069 # avg LSQ occupancy (insn's)
lsq_rate                     1.1908 # avg LSQ dispatch rate (insn/cycle)
lsq_latency                  1.6014 # avg LSQ occupant latency (cycle's)
lsq_full                     0.0237 # fraction of time (cycle's) LSQ was full
sim_slip                  144999405 # total number of slip cycles
avg_sim_slip                14.4999 # the average slip between issue and retirement
bpred_bimod.lookups          170733 # total number of bpred lookups
bpred_bimod.updates          170112 # total number of updates
bpred_bimod.addr_hits        144241 # total number of address-predicted hits
bpred_bimod.dir_hits         144643 # total number of direction-predicted hits (includes addr-hits)
bpred_bimod.misses            25469 # total number of misses
bpred_bimod.jr_hits            8120 # total number of address-predicted hits for JR's
bpred_bimod.jr_seen            8187 # total number of JR's seen
bpred_bimod.jr_non_ras_hits.PP          379 # total number of address-predicted hits for non-RAS JR's
bpred_bimod.jr_non_ras_seen.PP          411 # total number of non-RAS JR's seen
bpred_bimod.bpred_addr_rate    0.8479 # branch address-prediction rate (i.e., addr-hits/updates)
bpred_bimod.bpred_dir_rate    0.8503 # branch direction-prediction rate (i.e., all-hits/updates)
bpred_bimod.bpred_jr_rate    0.9918 # JR address-prediction rate (i.e., JR addr-hits/JRs seen)
bpred_bimod.bpred_jr_non_ras_rate.PP    0.9221 # non-RAS JR addr-pred rate (ie, non-RAS JR hits/JRs seen)
bpred_bimod.retstack_pushes         7859 # total number of address pushed onto ret-addr stack
bpred_bimod.retstack_pops         7803 # total number of address popped off of ret-addr stack
bpred_bimod.used_ras.PP         7776 # total number of RAS predictions used
bpred_bimod.ras_hits.PP         7741 # total number of RAS hits
bpred_bimod.ras_rate.PP    0.9955 # RAS prediction rate (i.e., RAS hits/used RAS)
il1.accesses               10171734 # total number of accesses
il1.hits                   10112620 # total number of hits
il1.misses                    59114 # total number of misses
il1.replacements              58859 # total number of replacements
il1.writebacks                    0 # total number of writebacks
il1.invalidations                 0 # total number of invalidations
il1.miss_rate                0.0058 # miss rate (i.e., misses/ref)
il1.repl_rate                0.0058 # replacement rate (i.e., repls/ref)
il1.wb_rate                  0.0000 # writeback rate (i.e., wrbks/ref)
il1.inv_rate                 0.0000 # invalidation rate (i.e., invs/ref)
il2.accesses                  59114 # total number of accesses
il2.hits                          0 # total number of hits
il2.misses                    59114 # total number of misses
il2.replacements              58859 # total number of replacements
il2.writebacks                    0 # total number of writebacks
il2.invalidations                 0 # total number of invalidations
il2.miss_rate                1.0000 # miss rate (i.e., misses/ref)
il2.repl_rate                0.9957 # replacement rate (i.e., repls/ref)
il2.wb_rate                  0.0000 # writeback rate (i.e., wrbks/ref)
il2.inv_rate                 0.0000 # invalidation rate (i.e., invs/ref)
dl1.accesses                1511088 # total number of accesses
dl1.hits                    1399106 # total number of hits
dl1.misses                   111982 # total number of misses
dl1.replacements             111726 # total number of replacements
dl1.writebacks                33624 # total number of writebacks
dl1.invalidations                 0 # total number of invalidations
dl1.miss_rate                0.0741 # miss rate (i.e., misses/ref)
dl1.repl_rate                0.0739 # replacement rate (i.e., repls/ref)
dl1.wb_rate                  0.0223 # writeback rate (i.e., wrbks/ref)
dl1.inv_rate                 0.0000 # invalidation rate (i.e., invs/ref)
dl2.accesses                 145606 # total number of accesses
dl2.hits                      33624 # total number of hits
dl2.misses                   111982 # total number of misses
dl2.replacements             111726 # total number of replacements
dl2.writebacks                33624 # total number of writebacks
dl2.invalidations                 0 # total number of invalidations
dl2.miss_rate                0.7691 # miss rate (i.e., misses/ref)
dl2.repl_rate                0.7673 # replacement rate (i.e., repls/ref)
dl2.wb_rate                  0.2309 # writeback rate (i.e., wrbks/ref)
dl2.inv_rate                 0.0000 # invalidation rate (i.e., invs/ref)
itlb.accesses              10171734 # total number of accesses
itlb.hits                  10171705 # total number of hits
itlb.misses                      29 # total number of misses
itlb.replacements                 0 # total number of replacements
itlb.writebacks                   0 # total number of writebacks
itlb.invalidations                0 # total number of invalidations
itlb.miss_rate               0.0000 # miss rate (i.e., misses/ref)
itlb.repl_rate               0.0000 # replacement rate (i.e., repls/ref)
itlb.wb_rate                 0.0000 # writeback rate (i.e., wrbks/ref)
itlb.inv_rate                0.0000 # invalidation rate (i.e., invs/ref)
dtlb.accesses               1511364 # total number of accesses
dtlb.hits                   1510725 # total number of hits
dtlb.misses                     639 # total number of misses
dtlb.replacements               511 # total number of replacements
dtlb.writebacks                   0 # total number of writebacks
dtlb.invalidations                0 # total number of invalidations
dtlb.miss_rate               0.0004 # miss rate (i.e., misses/ref)
dtlb.repl_rate               0.0003 # replacement rate (i.e., repls/ref)
dtlb.wb_rate                 0.0000 # writeback rate (i.e., wrbks/ref)
dtlb.inv_rate                0.0000 # invalidation rate (i.e., invs/ref)
sim_invalid_addrs                 0 # total non-speculative bogus addresses seen (debug var)
ld_text_base             0x00400000 # program text (code) segment base
ld_text_size                 234912 # program text (code) size in bytes
ld_data_base             0x10000000 # program initialized data segment base
ld_data_size               33097472 # program init'ed `.data' and uninit'ed `.bss' size in bytes
ld_stack_base            0x7fffc000 # program stack segment base (highest address in stack)
ld_stack_size                 16384 # program initial stack size
ld_prog_entry            0x00400140 # program entry point (initial PC)
ld_environ_base          0x7fff8000 # program environment base address address
ld_target_big_endian              0 # target executable endian-ness, non-zero if big endian
mem.page_count                  427 # total number of pages allocated
mem.page_mem                  1708k # total size of memory pages allocated
mem.ptab_misses                 435 # total first level page table misses
mem.ptab_accesses          63380650 # total page table accesses
mem.ptab_miss_rate           0.0000 # first level page table miss rate

