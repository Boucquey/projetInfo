using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Joueur
    {
        private Panel panelFond; // On sauvegarde le panel du jeu
        private PictureBox pBJoueur; // on crée la variable pour le pB du joueur
        private List<Tir> tirs = new List<Tir>(); // On a la liste des tirs du joueur (indispensable pour cintabiliser les points)
        private Boolean alive = true;   // Permet de savoir si le joueur doit exploser ou pas
        private Boolean destruction = false; //Permet de savoir si le joueur a utilisé son super tir ou pas
        private int combo; // Memorise le nombre d'enemis détruits afin d'avoir le super tir
        private int expl = 0; // Pour savoir où il en est dans la cinématique d'explosion
        private int totalPoint; // le score du joueur
        private Boolean joueur1; // Pour permettre de savoir si c'est le joueur 1 ou le joueur 2 (afin de changer la couleur)
     
        public Joueur(Panel panel, Point loc, bool j1) // constructeur, on recoit le panel, le point de départ dans le panel et si le joueur est le premier ou le deuxieme
        {
            pBJoueur = new PictureBox(); // on instencie le pB du joueur
            pBJoueur.Location = loc;    // on place le joueur a la bonne position dans le panel
            pBJoueur.BackColor = Color.Transparent; // Astuce pour avoir un fond transparent avec un bitmap. La couleur de fond est transparente
            Bitmap vaisseau;
            if (j1)                 // Si c'est le joueur 1 alors il sera blanc. On choisi un pixel ( dans un des coins) dont la couleur correspondra au transparent
            {
                joueur1 = true;     // variable pour les animations (pas avoir de changement de couleurs lors du changement d'image)
                vaisseau = new Bitmap(@".\vaisseau.bmp");
                vaisseau.MakeTransparent((vaisseau.GetPixel(0, vaisseau.Size.Height - 1)));
            }                       // si c'est le joueur 2
            else
            {
                joueur1 = false;    
                vaisseau = new Bitmap(@".\vaisseau2.bmp");
                vaisseau.MakeTransparent((vaisseau.GetPixel(0, vaisseau.Size.Height - 1)));
            }
            pBJoueur.Size = new Size(50, 50); // on donne la taille au pB
            pBJoueur.Image = vaisseau; // On donne au pB l'image
            pBJoueur.BringToFront();    // On met le pB au premier plan pour éviter des recouvrements
            this.panelFond = panel;     // On met le panel recu dans une des variables pour éviter de devoir faire des envois intempestifs
            panelFond.Controls.Add(pBJoueur); // on ajoute le joueur au controle du panel (pour qu'on ne voie pas le gros carré noir)
            pBJoueur.Refresh(); // Pour etre certain que l'image est bien présente dans le pB
            totalPoint = 0; // on mets son score a 0
            combo = 1000;   // On rempli sa jauge de super tir
        }


        public void Bouge(Keys direction) // pour le déplacement du joueur1 on recoit la touche directionnelle
        {
            Point p = new Point(); // on crée un nouveau point
            p = pBJoueur.Location; // Ce point est placé là où est le joueur

            switch (direction) // en fonction de la touche directionnelle, on incrémente la valeur d'x ou d'y du point
            {
                case Keys.Up:
                    if (p.Y > 0) 
                    { 
                    p.Y -= 10;
                    }
                    break;

                case Keys.Down:
                    if (p.Y+ pBJoueur.Height < panelFond.Height) // on évite que le joueur ne sorte du panel
                    {
                        p.Y += 10;
                    }
                    break;

                case Keys.Left:
                    if (p.X > 0)
                    {
                        p.X -= 10;
                    }
                    break;

                case Keys.Right:
                    if(p.X + pBJoueur.Width < panelFond.Width)
                    p.X += 10;
                    Image vaisseau; // si le joueur accélere, on ajoute du feu au niveau des réacteurs
                    if (joueur1) // on fait la différence entre le joueur 1 et le joueur 2
                    {
                        vaisseau = Image.FromFile(@".\vaisseauDroite.png");
                    }
                    else
                    {
                        vaisseau = Image.FromFile(@".\vaisseau2Droite.bmp");
                    }
                    pBJoueur.Image = vaisseau;
                    pBJoueur.Refresh();
                    break;
                

                default:
                    if (alive)  // au cas où aucune des touches n'est enfoncée et is le joueur est viviant
                    {
                        pBJoueur.BackColor = Color.Transparent; // on remet l'image par défaut
                        Image vaisseauStop;
                        if(joueur1){                    // le choix de l'image dépend du joueur
                        vaisseauStop = Image.FromFile(@".\vaisseau.png");
                        }else{
                            vaisseauStop = Image.FromFile(@".\vaisseau2.bmp");
                        }
                        pBJoueur.Image = vaisseauStop;
                    }
                    break;
            }
            pBJoueur.Location = p;              // le joueur est placé à la position du point
        }

        public void Mort() // Si le joueur meurt, on fait l'animation de son explosion
        {
            alive = false;      // il est considéré comme mort
            switch (this.expl) // on passe en revue les images de l'explosion
            {
                case 0: Image explosion = Image.FromFile(@".\expl1.png");
                        this.pBJoueur.Image = explosion;
                        pBJoueur.Refresh();
                        break;

                case 1: explosion = Image.FromFile(@".\expl2.png");
                        this.pBJoueur.Image = explosion;
                        pBJoueur.Refresh();
                        break;

                case 2: explosion = Image.FromFile(@".\expl3.png");
                        this.pBJoueur.Image = explosion;
                        pBJoueur.Refresh();  
                        break;
            }
        }

        public void Tir(Keys fire) // Quand le joueur appuye sur un des boutons pour tirer
        {
            if (fire.Equals(Keys.Space) && alive) // on vérifie si le joueur est encore vivant et si il appuye sur la barre d'espace
            {
                Tir tir = new Tir(this); // On ajoute un nouvel objet de type tir
                tirs.Add(tir); // on ajoute à la liste des tirs du joueur
                if (totalPoint > 0) // on retranche a chaque tir un point de score (on ne descend pas en dessous de zéro)
                {
                    totalPoint--;
                }
            }
            if (fire.Equals(Keys.Enter) && alive && combo == 1000 && !destruction) // on vérifie si le joueur appuye sur enter, si il est vivant et si sa jauge est rempli pour pouvoir faire le super tir
            {
                combo = 0; // on remet la jauge a zéro
                destruction = true; // on envoie au panel le fait que le joueur a déclanché son super tir
            }
        }

        public void Tir(string fire) // pemret de faire exactement la même chose mais avec le joueur2
        {
            if (fire.Equals("fi") && alive) // le flux de données envoie des strings
            {
                Tir tir = new Tir(this);
                tirs.Add(tir);
                if (totalPoint > 0)
                {
                    totalPoint--;
                }
            }
            if (fire.Equals("bo") && alive && combo == 1000 && !destruction)
            {
                combo = 0;
                destruction = true;
            }
        }

        public void AvanceTir() // permet de faire avancer les tirs 
        {
            for (int i = 0; i < tirs.Count; i++) // on balaie tout les tirs présents sur le panel
            {
                Point p = new Point(); // comme pour le déplacement du joueur juste que cette fois on avance que le long de l'axe X
                p = tirs[i].Location;
                p.X += tirs[i].Width;

                tirs[i].Location = p;
                tirs[i].forme.BringToFront(); // on le remet au premier plan pour éviter les recouvrements
                if (tirs[i].Location.X >= panelFond.Width) // si le tir dépasse le pannel, il est supprimé de la liste et du panel
                {
                    this.tirs.ElementAt(i).Dispose();
                    this.tirs.RemoveAt(i);
                }
            }
        }

        /// <>
        /// Methodes d'acces
        /// <>

        public int explo
        {
            get { return expl; }
            set { this.expl = value; }
        }

        public void Dispose() 
        {
            pBJoueur.Dispose();              
        }

        public PictureBox forme
        {
            get { return this.pBJoueur; }
        }

        public Point Location 
        {
            get { return this.pBJoueur.Location; }
            set { pBJoueur.Location = value; }
        }

        public Boolean enVie 
        {
            get { return this.alive; }
            set { this.alive = value; }
        }


        public List<Tir> Tirs
        {
            get { return this.tirs; }
            set { this.tirs = value; }
        }

        public Panel panel
        {
            get { return this.panelFond; }
            set { this.panelFond = value; }
        }

        public int Width 
        {
            get { return this.pBJoueur.Width; }
            set { pBJoueur.Width = value; }
        }


        public int Height
        {
            get { return this.pBJoueur.Height; }
            set { pBJoueur.Height = value; }
        }

        public Boolean destroy 
        {
            get { return this.destruction; }
            set { destruction = value; }
        
        }

        public int score
        {
            get { return this.totalPoint; }
            set { this.totalPoint = value; }
        }

        public int enchainement
        {
            get { return this.combo; }
            set { if(combo <= 995){this.combo = value;} }
        }
    }
}
