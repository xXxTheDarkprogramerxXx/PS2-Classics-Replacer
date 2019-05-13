pushd "%~dp0"
orbis-ctrl pkill eboot.bin
orbis-run /fsroot . /console:process /log:"eboot.log" /elf "eboot.bin"
popd
