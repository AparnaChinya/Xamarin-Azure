    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    namespace Demo
    {
        public partial class PageOne : ContentPage
        {
            Label result = new Label { Text = "Result" };
            public PageOne()
            {
                InitializeComponent();

                var num1 = new Entry { Placeholder = "Number 1" };

                var num2 = new Entry { Placeholder = "Number 2" };



                var add = new Button

                {

                    Text = "Add",

                    TextColor = Color.White,

                    BackgroundColor = Color.FromHex("77D065")

                };

                var sub = new Button

                {

                    Text = "Sub",

                    TextColor = Color.White,

                    BackgroundColor = Color.FromHex("77D065")

                };

                var mul = new Button

                {

                    Text = "Mul",

                    TextColor = Color.White,

                    BackgroundColor = Color.FromHex("77D065")

                };

                var div = new Button

                {

                    Text = "Div",

                    TextColor = Color.White,

                    BackgroundColor = Color.FromHex("77D065")

                };

                add.Clicked += (sender, args) =>

                {

                    var calc = new Calculator.PCL.Calculator();



                    var n1 = int.Parse(num1.Text);

                    var n2 = int.Parse(num2.Text);

                    result.Text = calc.Add(n1, n2).ToString();

                };

                sub.Clicked += (sender, args) =>

                {

                    var calc = new Calculator.PCL.Calculator();

                    var n1 = int.Parse(num1.Text);

                    var n2 = int.Parse(num2.Text);

                    result.Text = calc.Subtract(n1, n2).ToString();

                };

                mul.Clicked += (sender, args) =>

                {

                    var calc = new Calculator.PCL.Calculator();

                    var n1 = int.Parse(num1.Text);

                    var n2 = int.Parse(num2.Text);

                    result.Text = calc.Multiply(n1, n2).ToString();

                };

                div.Clicked += (sender, args) =>

                {

                    var calc = new Calculator.PCL.Calculator();

                    var n1 = int.Parse(num1.Text);

                    var n2 = int.Parse(num2.Text);





                    result.Text = calc.Divide(n1, n2).ToString();

                };

                var sl1 = new StackLayout

                {

                    Orientation = StackOrientation.Horizontal,

                    Children = { add, sub }

                };

                var sl2 = new StackLayout

                {

                    Orientation = StackOrientation.Horizontal,

                    Children = { mul, div }

                };


                this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

                this.Content = new StackLayout
                {
                    
                    Children =
                    {
                        num1, num2, sl1, sl2, result
                    }
                };

            }


        }
    }
