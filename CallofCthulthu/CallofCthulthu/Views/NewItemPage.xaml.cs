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


        Random dice = new Random();

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

            BindingContext = this;
        }

        //Save
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
           
        }

        //Cancel
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }


        //Stepper stepper = new Stepper
        //{
        //    Maximum = 100,
        //    Increment = 1
        //};

        //private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    Item.Age += 1;
        //    Age.Text = Item.Age.ToString();

        //}

         //Roll 3 D6 
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

        //Roll 2D6
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
        //RollD6
        private int rolld6()
        {
            int d6 = dice.Next(1, 7);
            return d6;
        }
        //Roll Strength
        private void StrButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll3d6();
            Str.Text = roll.ToString();
            Item.Str = roll;
        }
        //Roll Con
        private void ConButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll3d6();
            Con.Text = roll.ToString();
            Item.Con = roll;
            calculateHp();
        }
        //Roll Size
        private void SizButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll2d6();
            Siz.Text = roll.ToString();
            Item.Siz = roll;
            calculateHp();
        }

        //Roll Dex
        private void DexButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll3d6();
            Dex.Text = roll.ToString();
            Item.Dex = roll;
        }

        //Roll App
        private void AppButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll3d6();
            app.Text = roll.ToString();
            Item.App = roll;
        }

        //Roll Int +6
        private void IntButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll2d6();
            Int.Text = roll.ToString();
            Item.Int = roll;
            calculateHobby();
        }
        //Roll Pow
        private void PowButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll3d6();
            Pow.Text = roll.ToString();
            Item.Pow = roll;
            calculateMp();
            calculateSanity();
        }

        //Roll Edu +6
        private void EduButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll2d6();
            Edu.Text = roll.ToString();
            Item.Edu = roll;
        }
        //Roll Luck
        private void LckButton_Clicked(object sender, EventArgs e)
        {
            int roll = roll3d6();
            Lck.Text = roll.ToString();
            Item.Luck = roll;
        }

        //Roll All
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
            calculateHobby();
            
            saveFacts();
        }
        //Calculate Hp
        private void calculateHp()
        {
            int siz = stringToInt(Siz.Text);
            int con = stringToInt(Con.Text);

            int total = siz + con;
            double hp = total / 10;

            hp = Math.Floor(hp);
            Hp.Text = hp.ToString();
        }

        //Calculate Mp
        private void calculateMp()
        {
            int pow = Item.Pow;

            int mp = pow;
            mp =  mp/5;
            Mp.Text = mp.ToString();
            Item.Mp = mp;
        }
        //Calculate Sanity
        private void calculateSanity()
        {
            int sanity = Item.Pow;
            San.Text = sanity.ToString();
            Item.Sanity = sanity;
        }
        //String to int
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
        //Set Item values
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
        //Save  Name
        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = Name.Text;
            Item.Name = name;
        }
        //Save Player
        private void Player_TextChanged(object sender, TextChangedEventArgs e)
        {
            string player = Play.Text;
            Item.Player = player;
        }
        //Save Sex
        private void Sex_TextChanged(object sender, TextChangedEventArgs e)
        {
            string sex = Sex.Text;
            Item.Sex = Sex.Text;
        }
        //Save Age
        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {
            int age = stringToInt(Age.Text);
            Item.Age = age;

        }
        //Save Occ
        private void saveOcc(object sender, TextChangedEventArgs e)
        {
            Item.Ocu = picker.SelectedItem.ToString();
           Item.OcuPoint= calculatePoints(picker.SelectedIndex);
        }

        //Decide if dex or str is higher
        private int dexOrStr()
        {
            if(Item.Str >= Item.Dex)
            {
                return 0;
            }

            else
            {
                return 1;
            }
        }
        //Decide if dex or str is higher
        private int appOrDex()
        {
            if (Item.App >= Item.Dex)
            {
                return 0;
            }

            else
            {
                return 1;
            }
        }
        //Calculate Points based on occupation and Stats.
        //Stats must be picked before Occupation
        private int calculatePoints(int i)
        {
            int points = 0;
            if (i == 0)
            {
                points = Item.Edu * 4;
                Item.CrMin = 30;
                Item.CrMax = 70;
            }

            else if(i == 1)
            {
                points = (Item.Edu * 2) + (Item.App * 2);
                Item.CrMin = 9;
                Item.CrMax = 40;
            }

            else if (i == 2)
            {
                points = ((Item.Edu * 2) + Item.Str * 2);
                Item.CrMin = 5;
                Item.CrMax = 30;
            }

            else if (i == 3)
            {
                points = Item.Edu * 4;
                Item.CrMin = 30;
                Item.CrMax = 80;
            }

            else if (i == 4)
            {
                int bigStat = dexOrStr();
                if(bigStat == 0)
                {
                    points = ((Item.Edu * 2) + Item.Str * 2);
                }
                else
                {
                    points = ((Item.Edu * 2) + Item.Dex * 2);
                }
                Item.CrMin = 9;
                Item.CrMax = 20;
            }

            else if (i == 5)
            {
                int bigStat = dexOrStr();
                if (bigStat == 0)
                {
                    points = ((Item.Edu * 2) + Item.Str * 2);
                }
                else
                {
                    points = ((Item.Edu * 2) + Item.Dex * 2);
                }
                Item.CrMin = 9;
                Item.CrMax = 30;
            }

            else if (i == 6)
            {
                points = Item.Edu * 4;
                Item.CrMin = 30;
                Item.CrMax = 80;            }

            else if (i == 7)
            {
                int bigStat = dexOrStr();
                if (bigStat == 0)
                {
                    points = ((Item.Edu * 2) + Item.Str * 2);
                }
                else
                {
                    points = ((Item.Edu * 2) + Item.Dex * 2);
                }
                Item.CrMin = 9;
                Item.CrMax = 30;
            }

            else if (i == 8)
            {
                int bigStat = dexOrStr();
                if (bigStat == 0)
                {
                    points = ((Item.Edu * 2) + Item.Str * 2);
                }
                else
                {
                    points = ((Item.Edu * 2) + Item.Dex * 2);
                }
                Item.CrMin = 20;
                Item.CrMax = 60;
            }

            else if (i == 9)
            {
                points = Item.Edu * 4;
                Item.CrMin = 9;
                Item.CrMax = 40;
            }

            else
            {
                points = 55;
            }

            
            return points;

        }

        //Calculate Hobby points based on int
        private void calculateHobby()
        {
            int hobby = Item.Int * 2;
            Item.HobbyPoint = hobby;
        }
    }
}