using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System;
using Android.Support.Design.Widget;
using Java.Security;
using Android.Drm;
using Android.Provider;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Android.Gms.Tasks;
using Java.Lang;
using Firebase.Firestore;
using Java.Util;
using Firebase.Firestore.Core;
using Plugin.CloudFirestore;

namespace Recipe.Mobile.Scanner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button loginButton;
        private EditText emailEditText;
        private EditText passwordEditText;
        private Button registerButton;
        private string password = "Password";
        private string email = "email";
        private FirebaseAuth mAuth;




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            
            mAuth = FirebaseAuth.GetInstance(FirebaseApp.Instance);
            var reference = CrossCloudFirestore.Current.Instance;
            mAuth.CreateUserWithEmailAndPassword(email, password);

           
            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);
            registerButton = FindViewById<Button>(Resource.Id.goToRegisterButton);
        
            this.FindViewById<Button>(Resource.Id.loginButton).Click += this.Message;

            //registerButton.Click += delegate
            //{
            //    SetContentView(Resource.Layout.activity_register);
            //};

            loginButton.Click += LoginButton_Click;
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            HashMap map = new HashMap();
            map.Put("email", email);
            map.Put("password", password);

          //  DocumentReference documentReference = firebaseFirestoreDatabase.Collection("users").Document();
            //documentReference.Set(map);
        }

        public void Message(object sender, EventArgs e)
        {
            Toast.MakeText(this, "You clicked Button. Email: " + emailEditText.Text + " Pass: " + passwordEditText.Text, ToastLength.Long).Show();
        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}