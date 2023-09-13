using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using game.gameclasses;

namespace game {
    public partial class Form1 : Form {

        /*
            * 
            * Troll Room -- Forest
            *    |
            *  Cave  -----  Dungeon  
         * */

        Room room0;
        Room room1;
        Room room2;
        Room room3;

        Room[] map;

        private Actor _player;

        public Form1() {
            InitializeComponent();
            InitGame();
            StartGame();
        }

        private void InitGame() {
            room0 = new Room("Troll Room", "a dank, dark room that smells of troll", -1, 2, -1, 1);
            room1 = new Room("Forest", "a light, airy forest shimmering with sunlight", -1, -1, 0, -1);
            room2 = new Room("Cave", "a vast cave with walls covered by luminous moss", 0, -1, -1, 3);
            room3 = new Room("Dungeon", "a gloomy dungeon. Rats scurry across its floor", -1, -1, 2, -1);

            map = new Room[4];

            map[0] = room0;
            map[1] = room1;
            map[2] = room2;
            map[3] = room3;

            _player = new Actor("You", "The Player", room0);
        }

        private void StartGame() {
            outputTB.Text = $"Welcome to the Great Adventure!\nYou are in the {_player.Location.Name}. It is {_player.Location.Description}\n";
            outputTB.AppendText("Where do you want to go now?\n");
            outputTB.AppendText("Click a direction button: N, S, W or E.\n");
        }

        private void LookBtn_Click(object sender, EventArgs e) {
            outputTB.Text = $"You are in the {_player.Location.Name}. It is {_player.Location.Description}\n";
        }

        private void MovePlayer(int newpos) {
            if (newpos == -1) {
                outputTB.Text = "There is no exit in that direction\n";
            } else {
                _player.Location = map[newpos];
                outputTB.Text = $"You are now in the {_player.Location.Name}\n";
            }
        }

        private void NBtn_Click(object sender, EventArgs e) {
            MovePlayer(_player.Location.N);
        }

        private void WBtn_Click(object sender, EventArgs e) {
            MovePlayer(_player.Location.W);
        }

        private void EBtn_Click(object sender, EventArgs e) {
            MovePlayer(_player.Location.E);
        }

        private void SBtn_Click(object sender, EventArgs e) {
            MovePlayer(_player.Location.S);
        }
    }
}
