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
        if(turniej>mi){
            MessageBox.Show("Rozmiar turnieju nie może być większy niż liczba rodziców.");
            return;
        }
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
            txtRaport.Text+=j+"\t"+x1[j]+"\t"+x2[j]+"\t"+ocena[j]+Environment.NewLine;
        }
        for(int it=1;it<=iteracje;it++){
        double[] p1=new double[lambda];
        double[] p2=new double[lambda];
        for(int k=0;k<lambda;k++){
            bool[] wturnieju=new bool[mi];
            int ile=0;
            while(ile<turniej){
                int kandydat=losuj.Next(mi);
                if(wturnieju[kandydat]==false){
                    wturnieju[kandydat]=true;
                    ile++;
                }
            }
            int zwyciezca=-1;
            for(int j=0;j<mi;j++){
                if(wturnieju[j]==true){
                    if(zwyciezca==-1){
                        zwyciezca=j;
                    }
                    if(ocena[j]>ocena[zwyciezca]){
                        zwyciezca=j;
                    }
                }
            }
            p1[k]=x1[zwyciezca]+(losuj.NextDouble()*2-1)*mutacja;
            p2[k]=x2[zwyciezca]+(losuj.NextDouble()*2-1)*mutacja;
            if(p1[k]<0){
                p1[k]=0;
            }
            if(p1[k]>100){
                p1[k]=100;
            }
            if(p2[k]<0){
                p2[k]=0;
            }
            if(p2[k]>100){
                p2[k]=100;
            }
        }
            
        double[] w1=new double[mi+lambda];
        double[] w2=new double[mi+lambda];
        double[] wocena=new double[mi+lambda];
        for(int j=0;j<mi;j++){
            w1[j]=x1[j];
            w2[j]=x2[j];
            wocena[j]=ocena[j];
        }
        for(int k=0;k<lambda;k++){
            w1[mi+k]=p1[k];
            w2[mi+k]=p2[k];
            wocena[mi+k]=Stategia.oblicz(p1[k],p2[k]);
        }
        for(int i=0;i<mi;i++){
            int najl=i;
            for(int j=i+1;j<mi+lambda;j++){
                if(wocena[j]>wocena[najl]){
                    najl=j;
                }
            }
            double temp=w1[i];
            w1[i]=w1[najl];
            w1[najl]=temp;
            temp=w2[i];
            w2[i]=w2[najl];
            w2[najl]=temp;
            temp=wocena[i];
            wocena[i]=wocena[najl];
            wocena[najl]=temp;
        }
        for(int j=0;j<mi;j++){
            x1[j]=w1[j];
            x2[j]=w2[j];
            ocena[j]=wocena[j];
        }
        txtRaport.Text+=Environment.NewLine+"Iteracja:"+it+Environment.NewLine;
        txtRaport.Text+="osobnik\tx1\tx2\tF"+Environment.NewLine;
        for(int j=0;j<mi;j++){
            txtRaport.Text+=j+"\t"+x1[j]+"\t"+x2[j]+"\t"+ocena[j]+Environment.NewLine;
        }
        }
        txtRaport.Text+=Environment.NewLine+"Najlepsze rozwiązanie: x1="+x1[0]+" x2"+x2[0]+" F="+ocena[0]+Environment.NewLine;
        
    }
    
}
