.section .text
	.local methods
	.type methods,@function
	.balign 8
_methods:
methods:
	.skip 16
.section .text
	.local methods_end
	.type methods_end,@function
	.balign 8
_methods_end:
methods_end:
.section .text
	.local code_offsets
	.type code_offsets,@object
	.balign 8
_code_offsets:
code_offsets:

.section .text
	.local method_info_offsets
	.type method_info_offsets,@object
	.balign 8
_method_info_offsets:
method_info_offsets:

	.long 0,10,0,4
.section .text
	.local extra_method_table
	.type extra_method_table,@object
	.balign 8
_extra_method_table:
extra_method_table:

	.long 11,0,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0
.section .text
	.local extra_method_info_offsets
	.type extra_method_info_offsets,@object
	.balign 8
_extra_method_info_offsets:
extra_method_info_offsets:

	.long 0
.section .text
	.local class_name_table
	.type class_name_table,@object
	.balign 8
_class_name_table:
class_name_table:

	.hword 11, 1, 0, 0, 0, 0, 0, 0
	.hword 0, 0, 0, 0, 0, 0, 0, 0
	.hword 0, 0, 0, 0, 0, 0, 0
.section .text
	.local got_info_offsets
	.type got_info_offsets,@object
	.balign 8
_got_info_offsets:
got_info_offsets:

	.long 2,10,1,2
	.hword 0
	.byte 1,2
.section .text
	.local ex_info_offsets
	.type ex_info_offsets,@object
	.balign 8
_ex_info_offsets:
ex_info_offsets:

	.long 0,10,0,4
.section .text
	.balign 8
_unwind_info:
unwind_info:
	.local unwind_info
	.type unwind_info,@object
.section .text
	.local class_info_offsets
	.type class_info_offsets,@object
	.balign 8
_class_info_offsets:
class_info_offsets:

	.long 1,10,1,2
	.hword 0
	.byte 4

.section .text
	.local plt
	.type plt,@function
	.balign 16
_plt:
plt:
_mono_aot_UnityEngine_PerformanceReportingModule_plt:
mono_aot_UnityEngine_PerformanceReportingModule_plt:
_.Lp_0:
.Lp_0:

	.byte 255,37
	.long mono_aot_UnityEngine_PerformanceReportingModule_got - . + 12,0
	.size mono_aot_UnityEngine_PerformanceReportingModule_plt,.-mono_aot_UnityEngine_PerformanceReportingModule_plt
	.local plt_end
	.type plt_end,@function
_plt_end:
plt_end:
.section .text
	.local mono_image_table
	.type mono_image_table,@object
	.balign 8
_mono_image_table:
mono_image_table:

	.long 1
	.string "UnityEngine.PerformanceReportingModule"
	.string "93396857-54AE-49DF-896C-7F6FACDDF9E1"
	.string ""
	.string ""
	.balign 8

	.long 0,0,0,0,0
.section .bss
	.balign 8
	.local mono_aot_UnityEngine_PerformanceReportingModule_got
	.type mono_aot_UnityEngine_PerformanceReportingModule_got,@object
_mono_aot_UnityEngine_PerformanceReportingModule_got:
mono_aot_UnityEngine_PerformanceReportingModule_got:
	.skip 24
_got_end:
got_end:
.section .data
	.local mono_aot_got_addr
	.type mono_aot_got_addr,@object
	.balign 8
_mono_aot_got_addr:
mono_aot_got_addr:
	.balign 8
	.quad mono_aot_UnityEngine_PerformanceReportingModule_got
.section .data
	.balign 8
_mono_aot_file_info:
mono_aot_file_info:
	.local mono_aot_file_info
	.type mono_aot_file_info,@object

	.long 2,24,1,0,2,51472895,1024,1024
	.long 128,0,0,0,0,0,0
.section .data
	.local blob
	.type blob,@object
	.balign 8
_blob:
blob:

	.byte 80,12,0,39,0,128,144,16,0,0,1
.section .text
	.local mono_assembly_guid
	.type mono_assembly_guid,@object
_mono_assembly_guid:
mono_assembly_guid:
	.string "93396857-54AE-49DF-896C-7F6FACDDF9E1"
.section .text
	.local mono_aot_version
	.type mono_aot_version,@object
_mono_aot_version:
mono_aot_version:
	.string "67"
.section .text
	.local mono_runtime_version
	.type mono_runtime_version,@object
_mono_runtime_version:
mono_runtime_version:
	.string ""
.section .text
	.local mono_aot_assembly_name
	.type mono_aot_assembly_name,@object
_mono_aot_assembly_name:
mono_aot_assembly_name:
	.string "UnityEngine.PerformanceReportingModule"
.section .text
	.balign 8
_.Lglobals_hash:
.Lglobals_hash:

	.hword 37, 3, 0, 0, 0, 6, 0, 0
	.hword 0, 5, 0, 14, 0, 16, 0, 0
	.hword 0, 1, 0, 8, 0, 10, 38, 0
	.hword 0, 0, 0, 0, 0, 9, 0, 15
	.hword 0, 0, 0, 0, 0, 0, 0, 0
	.hword 0, 20, 40, 2, 37, 12, 0, 17
	.hword 0, 18, 0, 0, 0, 0, 0, 0
	.hword 0, 0, 0, 4, 39, 19, 0, 0
	.hword 0, 0, 0, 0, 0, 0, 0, 0
	.hword 0, 0, 0, 7, 0, 11, 0, 13
	.hword 0, 21, 0
.section .text
_name_0:
name_0:
	.string "methods"
.section .text
_name_1:
name_1:
	.string "methods_end"
.section .text
_name_2:
name_2:
	.string "code_offsets"
.section .text
_name_3:
name_3:
	.string "method_info_offsets"
.section .text
_name_4:
name_4:
	.string "extra_method_table"
.section .text
_name_5:
name_5:
	.string "extra_method_info_offsets"
.section .text
_name_6:
name_6:
	.string "class_name_table"
.section .text
_name_7:
name_7:
	.string "got_info_offsets"
.section .text
_name_8:
name_8:
	.string "ex_info_offsets"
.section .text
_name_9:
name_9:
	.string "unwind_info"
.section .text
_name_10:
name_10:
	.string "class_info_offsets"
.section .text
_name_11:
name_11:
	.string "plt"
.section .text
_name_12:
name_12:
	.string "plt_end"
.section .text
_name_13:
name_13:
	.string "mono_image_table"
.section .text
_name_14:
name_14:
	.string "mono_aot_got_addr"
.section .text
_name_15:
name_15:
	.string "mono_aot_file_info"
.section .text
_name_16:
name_16:
	.string "blob"
.section .text
_name_17:
name_17:
	.string "mono_assembly_guid"
.section .text
_name_18:
name_18:
	.string "mono_aot_version"
.section .text
_name_19:
name_19:
	.string "mono_runtime_version"
.section .text
_name_20:
name_20:
	.string "mono_aot_assembly_name"
.section .data
	.balign 8
_.Lglobals:
.Lglobals:
	.balign 8
	.quad .Lglobals_hash
	.balign 8
	.quad name_0
	.balign 8
	.quad methods
	.balign 8
	.quad name_1
	.balign 8
	.quad methods_end
	.balign 8
	.quad name_2
	.balign 8
	.quad code_offsets
	.balign 8
	.quad name_3
	.balign 8
	.quad method_info_offsets
	.balign 8
	.quad name_4
	.balign 8
	.quad extra_method_table
	.balign 8
	.quad name_5
	.balign 8
	.quad extra_method_info_offsets
	.balign 8
	.quad name_6
	.balign 8
	.quad class_name_table
	.balign 8
	.quad name_7
	.balign 8
	.quad got_info_offsets
	.balign 8
	.quad name_8
	.balign 8
	.quad ex_info_offsets
	.balign 8
	.quad name_9
	.balign 8
	.quad unwind_info
	.balign 8
	.quad name_10
	.balign 8
	.quad class_info_offsets
	.balign 8
	.quad name_11
	.balign 8
	.quad plt
	.balign 8
	.quad name_12
	.balign 8
	.quad plt_end
	.balign 8
	.quad name_13
	.balign 8
	.quad mono_image_table
	.balign 8
	.quad name_14
	.balign 8
	.quad mono_aot_got_addr
	.balign 8
	.quad name_15
	.balign 8
	.quad mono_aot_file_info
	.balign 8
	.quad name_16
	.balign 8
	.quad blob
	.balign 8
	.quad name_17
	.balign 8
	.quad mono_assembly_guid
	.balign 8
	.quad name_18
	.balign 8
	.quad mono_aot_version
	.balign 8
	.quad name_19
	.balign 8
	.quad mono_runtime_version
	.balign 8
	.quad name_20
	.balign 8
	.quad mono_aot_assembly_name

	.long 0,0
	.globl mono_aot_module_UnityEngine_PerformanceReportingModule_info
	.type mono_aot_module_UnityEngine_PerformanceReportingModule_info,@object
	.balign 8
_mono_aot_module_UnityEngine_PerformanceReportingModule_info:
mono_aot_module_UnityEngine_PerformanceReportingModule_info:
	.balign 8
	.quad .Lglobals
.section .text
	.local mem_end
	.type mem_end,@object
	.balign 8
_mem_end:
mem_end:
