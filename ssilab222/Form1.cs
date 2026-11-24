namespace ssilab222;

public partial class Form1 : Form
{
    NumericUpDown numMi;
    NumericUpDown numLambda;
    NumericUpDown numTurniej;
    NumericUpDown numMutacja;
    NumericUpDown numIter;
    public Form1()
    {
        InitializeComponent();
        Text="Strategie";
        Size=new Size(500,666);
        Label lblMi=new Label{Text="Liczba rodziców:",Left=30,Top=30,AutoSize=true};
        numMi=new NumericUpDown{Left=220,Top=28,Width=80,Minimum=2,Maximum=1000,Value=4};
        Label lblLambda=new Label{Text="Liczba potomków:",Left=30,Top=60,AutoSize=true};
        numLambda=new NumericUpDown{Left=220,Top=58,Width=80,Minimum=1,Maximum=1000,Value=10};
        Label lblTurniej= new Label{Text="Rozmiar turnieju:",Left=30,Top=90,AutoSize=true};
        numTurniej=new NumericUpDown{Left=220,Top=88,Width=80,Minimum=1, Maximum=1000,Value=2};
        Label lblMutacja=new Label{Text="Poziom mutacji:", Left=30, Top=120,AutoSize=true};
        numMutacja=new NumericUpDown{Left=220,Top=118,Width=80,DecimalPlaces=2,Increment=0.5m, Minimum=0.01m,Maximum=100,Value=10};
        Label lblIter=new Label{Text="Liczba iteracji:", Left=30,Top=150,AutoSize=true};
        numIter=new NumericUpDown{Left=220,Top=148,Width=80,Minimum=1,Maximum=1000,Value=20};

        Controls.Add(lblMi);
        Controls.Add(numMi);
        Controls.Add(lblLambda);
        Controls.Add(numLambda);
        Controls.Add(lblTurniej);
        Controls.Add(numTurniej);
        Controls.Add(lblMutacja);
        Controls.Add(numMutacja);
        Controls.Add(lblIter);
        Controls.Add(numIter);

    }
}
