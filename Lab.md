Xamarin Azure Lab
===========
<br />

#1. XAMARIN 
1.	Start Visual Studio > File > New Project > Visual C# > Cross-Platform >Xamarin.Forms(Portable) > Give a name to the Project (DEMO) >Ok.
2.	Right Click DEMO(Portable) > Add > New Item > Forms Xaml Page > PageOne.xaml > OK.
3.	DEMO(Portable) > App.cs > Comment/Remove all the lines of code inside the constructor that is: App() and add the below line.
 
 MainPage = new NavigationPage(new PageOne());
 
4.	Open PageOne.xaml > Copy paste the below code inside the ContentPage Node.
 

```XML
<Grid>
  <Button x:Name="myButton" Text="Hello World" Font="20" Clicked="myButton_Click" HorizontalOptions="Center" VerticalOptions ="Center" />
 </Grid>

 ```

 
5.	Open PageOne.xaml.cs and insert the below code inside the namespace.
 

```csharp
    int count=0
    void myButton_Click(object sender, EventArgs args)
    {
        count++;
        myButton.Text = count.ToString();
    }
 
```


###CALCULATOR 
 
1.	Right Click on DEMO(Portable) > Add New Item> Visual C# > New Class >Name it Calculator.PCL.cs
2.	Add functions for Addition, Subtraction, Multiplication and Division.

Eg:

````csharp
        public int Add(int x, int y)
 
        {
            int z = x + y;
 
            return z;
        }


```

   3.. Replace the Below Code for the Constructor in PageOne.xaml.cs.

```csharp
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
 

```

#Azure Mobile Apps

##OBSERVABLE COLLECTION
 
1.	Open PageOne.xaml and Insert the below Code.
 
 ```chsarp

<AbsoluteLayout HorizontalOptions="FillAndExpand" VerticalOptions="FillAndExpand">
 
      <StackLayout
 
        AbsoluteLayout.LayoutFlags="All"
 
        AbsoluteLayout.LayoutBounds="0,0,1,1">
 
        <ListView ItemsSource="{Binding Sessions}"
 
                  VerticalOptions="FillAndExpand"
 
                  HasUnevenRows="False"                 
 
                  CachingStrategy="RecycleElement"
 
                  x:Name="myList">
 
          <ListView.ItemTemplate>
 
            <DataTemplate>
             
              <ImageCell ImageSource="{Binding Images}" Text="{Binding Desc}"/>
 
            </DataTemplate>
 
          </ListView.ItemTemplate>
 
        </ListView>
 
      </StackLayout>
    
 
    </AbsoluteLayout>
 
  </ContentPage.Content>
 
</ContentPage>

````
     
 
 
2.	PageOne.xaml.cs and insert the below code.
 
````chsarp
public class Session
 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Images { get; set; }
        
    }
 
         public ObservableCollection<Session> Sessions { get; set; }
        public ICommand GetSessionsCommand { get; set; }
 
        
        async Task GetSessions()
 
        {
 
            
                using (var client = new System.Net.Http.HttpClient())
 
                {
 
                    var json = await client.GetStringAsync("https://apchin-mobileapp.azurewebsites.net/api/Check");
                    
                    //Deserialize json
 
                    var items = JsonConvert.DeserializeObject<List<Session>>(json);
 
                    myList.ItemsSource = items;
 
                    //Load sessions into list
 
 
                }
 
        }
 
 

```

###Under the constructor call

````csharp

 Sessions = new ObservableCollection<Session>();
 
 Title = "Sessions";
 
 GetSessions();

```` 


