using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class FirebaseExample : MonoBehaviour
{
    void Start()
    {
        FirebaseDB.init();
        User user = new User("Luis",
            SystemInfo.deviceUniqueIdentifier,
            "valdivialuis1989@gmail.com");

        string json = JsonUtility.ToJson(user);
        print(json);
        //FirebaseDB.reference.Child("users").Child(user.id).SetRawJsonValueAsync(json); 
        FirebaseDB.reference.ChildAdded += HandleChildAdded;
    }

    void HandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.Log(args.DatabaseError.Message);
            return;
        }
        print(args.Snapshot);
    }
}
