using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class Users : MonoBehaviour
{
    [SerializeField] GameObject User;
    int j = 0;

    private void Awake() {
        FirebaseDB.init();
        printInConsole();
        instanciar();
    }

    void printInConsole()
    {
        FirebaseDB.instanceDB.GetReference("users").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.LogError("La cagaste kaumza");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot user in snapshot.Children)
                {
                    IDictionary dictUser = (IDictionary)user.Value;
                    Debug.Log("" + dictUser["name"] + " - " + dictUser["id"]);
                }
            }
        });
    }

    void instanciar()
    {
        FirebaseDatabase.DefaultInstance.GetReference("users").ValueChanged += HandleValueChanged;
        
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (e.Snapshot != null && e.Snapshot.ChildrenCount > 0) {
            foreach (var childSnapshot in e.Snapshot.Children) {
                Vector3 temp = new Vector3(-2.0f, -2.0f + (2.0f * j), 0.0f);
                Instantiate(User,temp,Quaternion.identity);
                j++;
            }
        }
    }
}
