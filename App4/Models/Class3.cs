using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App4.Models
{
    public class ScoreboardRepo
    {
        private ObservableCollection<Scoreboard> scoreboard;
        public ObservableCollection<Scoreboard> scoreboardCollection
        {
            get { return scoreboard; }
            set { this.scoreboard = value; }
        }

        public ScoreboardRepo()
        {
            scoreboard = new ObservableCollection<Scoreboard>();
            this.GenerateOrders2();
        }

        private void GenerateOrders2()
        {
            scoreboard.Add(new Scoreboard(615081, "Li", "Lin", "54 Islington Park St London N1 1PX", "English", 72, "s.png"));
            scoreboard.Add(new Scoreboard(411106, "Bai", "Hao", "37 Grove Road London SW46 9AK", "English", 12, "b.png"));
            scoreboard.Add(new Scoreboard(659412, "Utemaro", "Watase", "Grayrigg Cottage Kents Bank Rd Grange-Over-Sands LA11 7HD", "English", 24, "b.png"));
            scoreboard.Add(new Scoreboard(119331, "Hernández", "Ximena", "61 Richmond Avenue London N1 0LX", "English", 43, "s.png"));
            scoreboard.Add(new Scoreboard(729818, "Montandon", "Rachael", "38 Chester Road London SE19 4SZ", "English, French", 89, "g.png"));
            scoreboard.Add(new Scoreboard(442232, "Stager", "Isabelle", "25 Imperial Rd Windsor SL4 3RU", "English, French", 61, "s.png"));
            scoreboard.Add(new Scoreboard(168652, "Surbeck", "Peter", "1 Islington Green London N1 2XH", "English, French", 78, "g.png"));
            scoreboard.Add(new Scoreboard(203871, "Juric", "Jan", "St. Marys Church Upper St London N1 2TX", "English", 97, "g.png"));
            scoreboard.Add(new Scoreboard(479324, "Travers", "Millard", "9 Rectory Terrace High St Cambridge CB1 9HU", "English, French", 6, "b.png"));
            scoreboard.Add(new Scoreboard(690762, "Charpentier", "Leon", "52 West Street London NW78 6ZV", "English, French", 54, "s.png"));
            scoreboard.Add(new Scoreboard(604082, "Dupuis", "Louis", "10 Gardiner Rd Edinburgh EH4 3RR", "English, French", 17, "b.png"));
            scoreboard.Add(new Scoreboard(754641, "Sergeyevna", "Selidova", "Manchester House 50 High St Builth Wells LD2 3AD", "English", 30, "b.png"));
            scoreboard.Add(new Scoreboard(102966, "Aleskeevich", "Yagovkin", "5 Richmond Road London W49 6CF", "English", 41, "s.png"));




        }
    }
}
