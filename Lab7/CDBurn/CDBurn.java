package CDBurn;

import java.io.BufferedReader;
import java.io.File;
import java.io.InputStreamReader;
import java.util.LinkedList;
import java.util.List;

public class CDBurn {

    private List<File> listFiles = new LinkedList<>();
    private Watcher watcher;

    public void setWatcher(Watcher watcher) {
        this.watcher = watcher;
    }

    public void addFile(File file) {
        listFiles.add(file);
    }

    private void copyFiles() {
        changeProgress("Copy files to temp directory DiskBuffer");
        for (File file : listFiles) {
            Execute("cp -R " + file.getAbsolutePath() + " /home/lorem/DiskBuffer");
        }
    }

    private void createDirectory() {
        changeProgress("Create temp directory DiskBuffer");
        Execute("mkdir /home/lorem/DiskBuffer");
    }

    private void umountDisk() {
        changeProgress("Umount disk");
        Execute("umount /dev/hdc");
    }

    private void createISO() {
        changeProgress("Create ISO Disk.iso");
        Execute("mkisofs -joliet-long -r -o Disk.iso /home/lorem/DiskBuffer");
    }

    private void formatDisk() {
        changeProgress("Format CD disk");
        Execute("cdrecord -dev=1,0,0 -v -blank=fast");
    }

    private void writeFilesToDisk() {
        changeProgress("Record Disk.iso to CD");
        Execute("cdrecord -dev=1,0,0 -speed=16 -eject -v Disk.iso");
    }

    private void deleteISO() {
        changeProgress("Delete temp files");
        Execute("rm ./Disk.iso");
    }

    private void deleteFiles() {
        Execute("rm -rf /home/lorem/DiskBuffer");
    }

    private void changeProgress(String message) {
        watcher.setProgressValue(message);
    }

    public void burnFiles() {
        if (!listFiles.isEmpty()) {
                createDirectory();
                copyFiles();
                umountDisk();
                createISO();
                formatDisk();
                writeFilesToDisk();
                deleteISO();
                deleteFiles();
                changeProgress("Complete!");
            } else {
                watcher.showError("No files to record!");
                changeProgress("Error!");
            }
            watcher.endRecord();
            listFiles.clear();
    }

    private void Execute(String command) {
        Process process;
        BufferedReader reader;
        try {
            process = Runtime.getRuntime().exec(new String[]{"/bin/bash", "-c", "echo "
                    + System.getenv("PASSWORD") + " |  " + command});
            reader = new BufferedReader(new InputStreamReader(process.getInputStream()));
            String line;
            while ((line = reader.readLine()) != null) {

                if (line.contains(" written ")) {
                    watcher.setProgressValue(line.substring(0, line.indexOf(" written ")));
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}


