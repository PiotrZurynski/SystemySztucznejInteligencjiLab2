namespace ssilab222;

public partial class Form1 : Form
{
    NumericUpDown numMi;
    NumericUpDown numLambda;
    public Form1()
    {
        InitializeComponent();
        Text="Strategie";
        Size=new Size(500,666);
        Label lblMi=new Label{Text="Liczba rodziców:",Left=30,Top=30,AutoSize=true};
        numMi=new NumericUpDown{Left=220,Top=28,Width=80,Minimum=2,Maximum=1000,Value=4};
        Label lblLambda=new Label{Text="Liczba potomków:",Left=30,Top=60,AutoSize=true};
        numLambda=new NumericUpDown{Left=220,Top=58,Width=80,Minimum=1,Maximum=1000,Value=10};

        Controls.Add(lblMi);
        Controls.Add(numMi);
        Controls.Add(lblLambda);
        Controls.Add(numLambda);
        
    }
}
