/*
 * Created by SharpDevelop.
 * User: aleks
 * Date: 22.09.2021
 * Time: 8:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;


class MyPoint
{
	string Name;
	double x;
	double y;
	double dx;
	double dy;
	byte[] Color;
	
	public MyPoint(int lim_x, int lim_y)
	{
		Random rnd= new Random();
		x=rnd.Next(lim_x);
		y=rnd.Next(lim_y);
		dx = 2*rnd.NextDouble()-1;
		dy = 2*rnd.NextDouble()-1;
		Color = new byte[3];
		rnd.NextBytes(Color);
		Name="";
	}
	
	public string Position_Get()
	{
		return "Координата x: "+x+"   Координата y: "+y;
	}
	
	public string Speed_Get()
	{
		return "Скорость по x: "+dx+"   Скорость по y:"+dy;
	}
	
	public string Name_Get()
	{
		return "Имя: "+Name;
	}
	
	public void Name_Set(string txt)
	{
		Name=txt;
	}
	
	public void Speed_Set(int dx, int dy)
	{
		this.dx=dx;
		this.dy=dy;
	}
}

class MyLabel:Label
{
	public MyLabel():base()
	{
		BorderStyle=BorderStyle.Fixed3D;
		Font=new Font("Comic Sans MS",10,FontStyle.Bold);
		TextAlign=ContentAlignment.MiddleCenter;
	}
}

class MyForm:Form
{
	Pen p;
	Graphics g;
	public MyForm():base()
	{
		Width=525;
		Height=580;
		StartPosition=FormStartPosition.CenterScreen;
		FormBorderStyle=FormBorderStyle.FixedToolWindow;
		Text="Координаты курсора";
		MyLabel lbl_Name=new MyLabel();
		lbl_Name.Bounds=new Rectangle(5,5,500,30);
		Controls.Add(lbl_Name);
		MyLabel lbl_Pos=new MyLabel();
		lbl_Pos.Bounds=new Rectangle(5,45,500,30);
		Controls.Add(lbl_Pos);
		MyLabel lbl_Speed=new MyLabel();
		lbl_Speed.Bounds=new Rectangle(5,85,500,30);
		Controls.Add(lbl_Speed);
		Panel pnl=new Panel();
		pnl.Width=lbl_Name.Width;
		pnl.Height=400;
		pnl.Top=lbl_Speed.Bottom+5;
		pnl.Left=lbl_Speed.Left;
		pnl.BorderStyle=BorderStyle.Fixed3D;
		pnl.BackColor=Color.Yellow;
		pnl.Cursor=Cursors.Hand;
		/*p=new Pen(Color.Blue,3);
		g=pnl.CreateGraphics();
		pnl.MouseMove+=(obj,ea)=>
		{
         	pnl.Refresh();
        	lbl.Text="Горизонталь: "+ea.X;
         	lbl.Text+="     ";
         	lbl.Text+="Вертикаль: "+ea.Y;
         	g.DrawLine(p,new Point(0,ea.Y),new Point(pnl.ClientSize.Width,ea.Y));
        	g.DrawLine(p,new Point(ea.X,0),new Point(ea.X,pnl.ClientSize.Height));
        	//g.DrawRectangle(p,new Rectangle(ea.X,ea.Y,1,1));
     	};
     	pnl.MouseLeave+=(obj,ae)=>{
     	   lbl.Text="";
      	   pnl.Refresh();
     	};*/
     	this.Controls.Add(pnl);
	}
	~MyForm()
	{
		g.Dispose();
		p.Dispose();
	}
}

class Program
{
	[STAThread]
	public static void Main(string[] args)
	{
		Application.Run(new MyForm());
	}
}