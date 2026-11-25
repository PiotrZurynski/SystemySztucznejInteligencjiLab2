namespace ssilab222;

public partial class Form1 : Form
{
    NumericUpDown numMi;
    NumericUpDown numLambda;
    NumericUpDown numTurniej;
    NumericUpDown numMutacja;
    NumericUpDown numIter;
    TextBox txtRaport;
    Random losuj=new Random();
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
        Button btnStart=new Button{Text="Start",Left=30,Top=190,Width=90,Height=30};
        btnStart.Click+=btnStart_Click;
        txtRaport=new TextBox{Left=30,Top=240,Width=430,Height=350,Multiline=true,ScrollBars=ScrollBars.Vertical};



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
        Controls.Add(btnStart);
        Controls.Add(txtRaport);

    }
    void btnStart_Click(object? sender, EventArgs e){
        int mi=(int)numMi.Value;
        int lambda=(int)numLambda.Value;
        int turniej=(int)numTurniej.Value;
        double mutacja=(double)numMutacja.Value;
        int iteracje=(int)numIter.Value;
        txtRaport.Text="mi="+mi+" lambda="+lambda+" turniej="+turniej+" mutacja="+mutacja+Environment.NewLine;
        txtRaport.Text+="iteracje="+iteracje+Environment.NewLine;

        double[] x1=new double[mi];
        double[] x2=new double[mi];
        double[] ocena=new double[mi];
        for(int j=0;j<mi;j++){
            x1[j]=losuj.NextDouble()*100;
            x2[j]=losuj.NextDouble()*100;
            ocena[j]=Stategia.oblicz(x1[j],x2[j]);
        }
        txtRaport.Text+=Environment.NewLine+"Pula rodziców przed ewolucją"+Environment.NewLine;
        txtRaport.Text+="osobnik\tx1\tx2\tF"+Environment.NewLine;
        for(int j=0;j<mi;j++){
            txtRaport.Text+=j+"\t"+x1[j]+"\t"+ocena[j]+Environment.NewLine;
        }
    }
}
