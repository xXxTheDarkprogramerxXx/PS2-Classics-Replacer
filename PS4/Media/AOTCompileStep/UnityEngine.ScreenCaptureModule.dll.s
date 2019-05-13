.section .text
	.local methods
	.type methods,@function
	.balign 8
_methods:
methods:
	.skip 16
.section .text
	.balign 16
_.Lm_0:
.Lm_0:
	.local wrapper_managed_to_native_UnityEngine_ScreenCapture_CaptureScreenshot_string_int
	.type wrapper_managed_to_native_UnityEngine_ScreenCapture_CaptureScreenshot_string_int,@function
_wrapper_managed_to_native_UnityEngine_ScreenCapture_CaptureScreenshot_string_int:
wrapper_managed_to_native_UnityEngine_ScreenCapture_CaptureScreenshot_string_int:

	.byte 72,131,236,104,72,137,100,36,48,72,137,92,36,32,72,137,108,36,40,76,137,100,36,56,76,137,108,36,64,76,137,116
	.byte 36,72,76,137,124,36,80,72,137,124,36,88,72,137,116,36,96,232
	.long .Lp_1 - . -4
	.byte 72,137,68,36,8,76,139,24,76,137,28,36,76,141,28,36,76,137,24,72,139,124,36,88,72,99,116,36,96,72,137,100
	.byte 36,48,72,51,192,232
	.long .Lp_2 - . -4
	.byte 72,139,12,36,76,139,92,36,8,73,137,11,72,131,196,104,195

	.size wrapper_managed_to_native_UnityEngine_ScreenCapture_CaptureScreenshot_string_int,.-wrapper_managed_to_native_UnityEngine_ScreenCapture_CaptureScreenshot_string_int
_.Lme_0:
.Lme_0:
.section .text
	.balign 16
_.Lm_1:
.Lm_1:
	.local UnityEngine_ScreenCapture_CaptureScreenshot_string
	.type UnityEngine_ScreenCapture_CaptureScreenshot_string,@function
_UnityEngine_ScreenCapture_CaptureScreenshot_string:
UnityEngine_ScreenCapture_CaptureScreenshot_string:

	.byte 72,131,236,8,72,137,60,36,51,246,232
	.long .Lp_3 - . -4
	.byte 72,131,196,8,195

	.size UnityEngine_ScreenCapture_CaptureScreenshot_string,.-UnityEngine_ScreenCapture_CaptureScreenshot_string
_.Lme_1:
.Lme_1:
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

	.long .Lm_0 - methods,.Lm_1 - methods,-1

.section .text
	.local method_info_offsets
	.type method_info_offsets,@object
	.balign 8
_method_info_offsets:
method_info_offsets:

	.long 3,10,1,2
	.hword 0
	.byte 1,2,255,255,255,255,253
.section .text
	.local extra_method_table
	.type extra_method_table,@object
	.balign 8
_extra_method_table:
extra_method_table:

	.long 11,0,0,0,0,0,0,0
	.long 0,0,0,0,0,5,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0
.section .text
	.local extra_method_info_offsets
	.type extra_method_info_offsets,@object
	.balign 8
_extra_method_info_offsets:
extra_method_info_offsets:

	.long 1,0,5
.section .text
	.local class_name_table
	.type class_name_table,@object
	.balign 8
_class_name_table:
class_name_table:

	.hword 11, 1, 0, 0, 0, 0, 0, 0
	.hword 0, 0, 0, 0, 0, 0, 0, 2
	.hword 0, 0, 0, 0, 0, 0, 0
.section .text
	.local got_info_offsets
	.type got_info_offsets,@object
	.balign 8
_got_info_offsets:
got_info_offsets:

	.long 2,10,1,2
	.hword 0
	.byte 64,2
.section .text
	.local ex_info_offsets
	.type ex_info_offsets,@object
	.balign 8
_ex_info_offsets:
ex_info_offsets:

	.long 3,10,1,2
	.hword 0
	.byte 91,3,255,255,255,255,162
.section .text
	.balign 8
_unwind_info:
unwind_info:
	.local unwind_info
	.type unwind_info,@object

	.byte 26,12,7,8,144,1,68,14,112,74,131,10,69,134,9,69,140,7,69,141,6,69,142,5,69,143,4,8,12,7,8,144
	.byte 1,68,14,16
.section .text
	.local class_info_offsets
	.type class_info_offsets,@object
	.balign 8
_class_info_offsets:
class_info_offsets:

	.long 2,10,1,2
	.hword 0
	.byte 97,7

.section .text
	.local plt
	.type plt,@function
	.balign 16
_plt:
plt:
_mono_aot_UnityEngine_ScreenCaptureModule_plt:
mono_aot_UnityEngine_ScreenCaptureModule_plt:
_.Lp_0:
.Lp_0:

	.byte 255,37
	.long mono_aot_UnityEngine_ScreenCaptureModule_got - . + 12,0
_.Lp_1:
.Lp_1:
	.local plt__jit_icall_mono_get_lmf_addr
	.type plt__jit_icall_mono_get_lmf_addr,@function
_plt__jit_icall_mono_get_lmf_addr:
plt__jit_icall_mono_get_lmf_addr:

	.byte 255,37
	.long mono_aot_UnityEngine_ScreenCaptureModule_got - . + 20,67
	.size plt__jit_icall_mono_get_lmf_addr,.-plt__jit_icall_mono_get_lmf_addr
_.Lp_2:
.Lp_2:
	.local plt__icall_native_UnityEngine_ScreenCapture_CaptureScreenshot_string_int
	.type plt__icall_native_UnityEngine_ScreenCapture_CaptureScreenshot_string_int,@function
_plt__icall_native_UnityEngine_ScreenCapture_CaptureScreenshot_string_int:
plt__icall_native_UnityEngine_ScreenCapture_CaptureScreenshot_string_int:

	.byte 255,37
	.long mono_aot_UnityEngine_ScreenCaptureModule_got - . + 28,87
	.size plt__icall_native_UnityEngine_ScreenCapture_CaptureScreenshot_string_int,.-plt__icall_native_UnityEngine_ScreenCapture_CaptureScreenshot_string_int
_.Lp_3:
.Lp_3:
	.local plt_UnityEngine_ScreenCapture_CaptureScreenshot_string_int
	.type plt_UnityEngine_ScreenCapture_CaptureScreenshot_string_int,@function
_plt_UnityEngine_ScreenCapture_CaptureScreenshot_string_int:
plt_UnityEngine_ScreenCapture_CaptureScreenshot_string_int:

	.byte 255,37
	.long mono_aot_UnityEngine_ScreenCaptureModule_got - . + 36,89
	.size plt_UnityEngine_ScreenCapture_CaptureScreenshot_string_int,.-plt_UnityEngine_ScreenCapture_CaptureScreenshot_string_int
	.size mono_aot_UnityEngine_ScreenCaptureModule_plt,.-mono_aot_UnityEngine_ScreenCaptureModule_plt
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

	.long 2
	.string "UnityEngine.ScreenCaptureModule"
	.string "9E1E6CF4-8248-4F63-A28C-5E716FADE991"
	.string ""
	.string ""
	.balign 8

	.long 0,0,0,0,0
	.string "mscorlib"
	.string "05F5323B-7393-4750-B4DA-F32CA2A54644"
	.string ""
	.string "b77a5c561934e089"
	.balign 8

	.long 1,2,0,0,0
.section .bss
	.balign 8
	.local mono_aot_UnityEngine_ScreenCaptureModule_got
	.type mono_aot_UnityEngine_ScreenCaptureModule_got,@object
_mono_aot_UnityEngine_ScreenCaptureModule_got:
mono_aot_UnityEngine_ScreenCaptureModule_got:
	.skip 48
_got_end:
got_end:
.section .data
	.local mono_aot_got_addr
	.type mono_aot_got_addr,@object
	.balign 8
_mono_aot_got_addr:
mono_aot_got_addr:
	.balign 8
	.quad mono_aot_UnityEngine_ScreenCaptureModule_got
.section .data
	.balign 8
_mono_aot_file_info:
mono_aot_file_info:
	.local mono_aot_file_info
	.type mono_aot_file_info,@object

	.long 2,48,4,3,2,51472895,1024,1024
	.long 128,0,0,0,0,0,0
.section .data
	.local blob
	.type blob,@object
	.balign 8
_blob:
blob:

	.byte 80,0,0,0,0,1,6,85,110,105,116,121,69,110,103,105,110,101,46,83,99,114,101,101,110,67,97,112,116,117,114,101
	.byte 58,67,97,112,116,117,114,101,83,99,114,101,101,110,115,104,111,116,32,40,115,116,114,105,110,103,44,105,110,116,41,0
	.byte 12,0,39,7,17,109,111,110,111,95,103,101,116,95,108,109,102,95,97,100,100,114,0,31,1,3,1,2,0,0,2,27
	.byte 0,0,128,144,16,0,0,1,4,128,144,16,0,0,1,193,0,0,8,193,0,0,5,193,0,0,4,193,0,0,2
.section .text
	.local mono_assembly_guid
	.type mono_assembly_guid,@object
_mono_assembly_guid:
mono_assembly_guid:
	.string "9E1E6CF4-8248-4F63-A28C-5E716FADE991"
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
	.string "UnityEngine.ScreenCaptureModule"
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
	.globl mono_aot_module_UnityEngine_ScreenCaptureModule_info
	.type mono_aot_module_UnityEngine_ScreenCaptureModule_info,@object
	.balign 8
_mono_aot_module_UnityEngine_ScreenCaptureModule_info:
mono_aot_module_UnityEngine_ScreenCaptureModule_info:
	.balign 8
	.quad .Lglobals
.section .text
	.local mem_end
	.type mem_end,@object
	.balign 8
_mem_end:
mem_end:
