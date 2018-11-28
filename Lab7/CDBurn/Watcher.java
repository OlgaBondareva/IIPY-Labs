package CDBurn;

public interface Watcher {
    void setProgressValue(String message);

    void endRecord();

    void showError(String message);
}
