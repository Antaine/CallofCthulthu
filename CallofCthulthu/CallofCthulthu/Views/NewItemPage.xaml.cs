using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CallofCthulthu.Models;
using System.ComponentModel;

namespace CallofCthulthu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage , INotifyPropertyChanged
    {
        public Item Item { get; set; }
        private string strRoll;
        public string StrRoll
        {
            get
            {
                return strRoll;
            }
            set
            {
                if (strRoll != value)
                {
                    strRoll = value;
                    this.OnPropertyChanged("Rolled");
                }
            }
        }


        Random dice = new Random();

        public void get_Roll(object btn)
        {
            var b = (Button)btn;
            Item.Str = dice.Next(1, 7);
        }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Name = "Character Name",
                Player = "Player Name",
                Age = 15,
                Str  = 0,
                Con = 0


            };

           // roll2d6();

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        Stepper stepper = new Stepper
        {
            Maximum = 100,
            Increment = 1
        };

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Item.Age += 1;
            Age.Text = Item.Age.ToString();

        }

        private int roll3d6()
        {
            int roll = 0;
            int roll3d6 = 0;
            for (int i = 0; i < 3; i++)
            {
                roll = dice.Next(1, 7);
                roll3d6 += roll;
            }
            roll3d6 *= 5;
            return roll3d6;
        }

        private int roll2d6()
        {
            int roll = 0;
            int roll2d6 = 0;
            for (int i = 0; i < 2; i++)
            {
                roll = dice.Next(1, 7);
                roll2d6 += roll;
            }

            roll2d6 += 6;
            roll2d6 *= 5;
            return roll2d6;
        }

        private int rolld6()
        {
            int d6 = dice.Next(1, 7);
            return d6;
        }

        private void StrButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll3d6();
            Str.Text = roll.ToString();
            Item.Str = roll;
        }

        private void ConButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll3d6();
            Con.Text = roll.ToString();
            Item.Con = roll;
            calculateHp();
        }

        private void SizButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll2d6();
            Siz.Text = roll.ToString();
            Item.Siz = roll;
            calculateHp();
        }

        private void DexButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll3d6();
            Dex.Text = roll.ToString();
            Item.Dex = roll;
        }

        private void AppButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll3d6();
            app.Text = roll.ToString();
            Item.App = roll;
        }

        private void IntButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll2d6();
            Int.Text = roll.ToString();
            Item.Int = roll;
        }

        private void PowButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll3d6();
            Pow.Text = roll.ToString();
            Item.Pow = roll;
            calculateMp();
            calculateSanity();
        }

        private void EduButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll2d6();
            Edu.Text = roll.ToString();
            Item.Edu = roll;
        }

        private void LckButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll3d6();
            Lck.Text = roll.ToString();
            Item.Luck = roll;
        }

        private void StatButton_Clicked(object sender, EventArgs e)
        {
            int strRoll = roll3d6();
            int conRoll = roll3d6();
            int sizRoll = roll2d6();
            int dexRoll = roll3d6();
            int appRoll = roll3d6();
            int intRoll = roll2d6();
            int powRoll = roll3d6();
            int eduRoll = roll2d6();
            int lckRoll = roll3d6();

            Str.Text = strRoll.ToString();
            Con.Text = conRoll.ToString();
            Siz.Text = sizRoll.ToString();
            Dex.Text = dexRoll.ToString();
            app.Text = appRoll.ToString();
            Int.Text = intRoll.ToString();
            Pow.Text = powRoll.ToString();
            Edu.Text = eduRoll.ToString();
            Lck.Text = lckRoll.ToString();

            Item.Str = strRoll;
            Item.Con = conRoll;
            Item.Siz = sizRoll;
            Item.Dex = dexRoll;
            Item.App = appRoll;
            Item.Int = intRoll;
            Item.Pow = powRoll;
            Item.Edu = eduRoll;
            Item.Luck = lckRoll;

            calculateHp();
            calculateMp();
            calculateSanity();
            saveFacts();
        }

        private void calculateHp()
        {
            int siz = stringToInt(Siz.Text);
            int con = stringToInt(Con.Text);

            int total = siz + con;
            double hp = total / 10;

            hp = Math.Floor(hp);
            Hp.Text = hp.ToString();
        }

        private void calculateMp()
        {
            int pow = Item.Pow
;

            int mp = pow;
            mp =  mp/5;
            Mp.Text = mp.ToString();
            Item.Mp = mp;
        }

        private void calculateSanity()
        {
            int sanity = Item.Pow;
            San.Text = sanity.ToString();
            Item.Sanity = sanity;
        }

        private int stringToInt(string stat)
        {
            int num = 0;
            try
            {
                num = Int32.Parse(stat);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            
            return num;
        }

        private void saveFacts()
        {
            string name = Name.Text;
            string player = Play.Text;
            string sex = Sex.Text;
            int age = stringToInt(Age.Text);

            Item.Name = name;
            Item.Player = player;
            Item.Sex = sex;
            Item.Age = age;
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = Name.Text;
            Item.Name = name;
        }

        private void Player_TextChanged(object sender, TextChangedEventArgs e)
        {
            string player = Play.Text;
            Item.Player = player;
        }

        private void Sex_TextChanged(object sender, TextChangedEventArgs e)
        {
            string sex = Sex.Text;
            Item.Sex = Sex.Text;
        }

        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {
            int age = stringToInt(Age.Text);
            Item.Age = age;

        }
    }
}