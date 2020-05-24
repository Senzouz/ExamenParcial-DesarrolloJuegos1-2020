using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class FirebaseDB
{
    private static string url = "https://pruebaupc01-3352a.firebaseio.com/";

    public static DatabaseReference reference;
    public static FirebaseDatabase instanceDB;

    public static void init()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(url);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        instanceDB = FirebaseDatabase.DefaultInstance;
    }
}
