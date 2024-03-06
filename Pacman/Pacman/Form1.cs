namespace Pacman
{
    public partial class Form1 : Form
    {

        static int count;
        CANVAS canvas;
        MAP map;
        PACMAN pacman;


        public Form1()
        {
            InitializeComponent();
            canvas = new CANVAS(PCT_CANVAS);
            map = new MAP();
            pacman = new PACMAN();
        }//end Form1



        //Pacman view controller
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    pacman.setDirection("up");
                    break;
                case Keys.Down:
                    pacman.setDirection("down");
                    break;
                case Keys.Left:
                    pacman.setDirection("left");
                    break;
                case Keys.Right:
                    pacman.setDirection("right");
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        } //end ProcessCmdKey

        private void TIMER_Tick(object sender, EventArgs e)
        {
            count++;
            canvas.drawMap(map, count, pacman, ScoreLabel);
            PCT_CANVAS.Refresh();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            count = 0;
            map.level  = new MAP().level; // Si tienes un método de reinicio en la clase MAP, llámalo aquí.
            pacman = new PACMAN(); // Si tienes un método de reinicio en la clase PACMAN, llámalo aquí.
            canvas = new CANVAS(PCT_CANVAS);
            canvas.drawMap(map, count, pacman, ScoreLabel); // Redibuja el mapa con el estado reiniciado.
            PCT_CANVAS.Refresh(); // Refresca el canvas.
        }
    }
}
