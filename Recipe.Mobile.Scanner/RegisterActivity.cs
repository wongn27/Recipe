using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Android.Support.V7.App;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Installations.Remote;
using Java.Util.Functions;

namespace Recipe.Mobile.Scanner
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            //emailEditText = FindViewById<EditText>(Resource.Id.emailRegEditText);
            //passwordEditText = FindViewById<EditText>(Resource.Id.passwordRegEditText);

        }

    }
}