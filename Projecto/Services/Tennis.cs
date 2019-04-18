using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecto.Services
{
    public class Tennis
    {
        private static int player1 = 1;
        private static int player2 = 2;
        private static string deuce = "DEUCE";
        private string advj1 = "ADVJ1";
        private string advj2 = "ADVJ2";
        private string winnj1 = "WINJ1";
        private string winnj2 = "WINJ2";

        public Models.TenisVieModel setPoint(int palyers, 
            string totalPointPlayer, 
            int consecutivePointPlayer1, 
            int consecutivePointPlayer2
            )
        {
         
            var tenisVieModel = new Models.TenisVieModel();

            if (totalPointPlayer == winnj1 || totalPointPlayer == winnj2)
            {
                tenisVieModel.resultPoint = "0 - 0 ";
                tenisVieModel.player2Id = 0;
                tenisVieModel.player2Name = "";
                tenisVieModel.player2Point = 0;
                tenisVieModel.player1Id = 0;
                tenisVieModel.player1Name = "";
                tenisVieModel.player1Point = 0;
                return tenisVieModel;
            }

            if (consecutivePointPlayer1 == 1 && consecutivePointPlayer2 == 0 && palyers == 1)
            {
                tenisVieModel.resultPoint = winnj1;
                return tenisVieModel;
            }

            if (consecutivePointPlayer2 == 1 && consecutivePointPlayer1 == 0 && palyers == 2)
            {
                tenisVieModel.resultPoint = winnj2;
                return tenisVieModel;
            }

            if (totalPointPlayer == deuce || totalPointPlayer == advj1 || totalPointPlayer == advj2)
            {
                if (palyers == player1)
                {
                    tenisVieModel.consecutivePointPlayer2 = consecutivePointPlayer2 + 0;
                    tenisVieModel.consecutivePointPlayer1 = consecutivePointPlayer1 + 1;
                    tenisVieModel.resultPoint = advj1;
                }

                if (palyers == player2)
                {
                    tenisVieModel.consecutivePointPlayer1 = consecutivePointPlayer1 + 0;
                    tenisVieModel.consecutivePointPlayer2 = consecutivePointPlayer2 + 1;
                    tenisVieModel.resultPoint = advj2;
                }
            }
            else
            {
                string[] resultPoint = totalPointPlayer.Split('-');
                int pointPlayer1 = int.Parse(resultPoint[0]);
                int pointPlayer2 = int.Parse(resultPoint[1]);

                if (palyers == player1)
                {

                    if (pointPlayer2 == 0)
                    {
                        tenisVieModel.player2Id = 2;
                        tenisVieModel.player2Name = "PLAYER 2";
                        tenisVieModel.player2Point = 0;
                    }

                    var pointWin = Services.Point.getPointWin(pointPlayer1);
                    if (pointWin.poinWin == 3)
                    {
                        if (tenisVieModel.player2Point == 0)
                        {
                            tenisVieModel.resultPoint = winnj1;
                            return tenisVieModel;
                        } else
                        {
                            tenisVieModel.resultPoint = "THE GAME IS OVER";
                            return tenisVieModel;
                        }
                    }
                    var pointPlayer = Services.Point.getPointPlayer(pointWin.poinWin + 1);

                    tenisVieModel.player1Id = 1;
                    tenisVieModel.player1Name = "PLAYER 1";
                    tenisVieModel.player1Point = (pointPlayer.poinPlay);

                    tenisVieModel.player2Point = (pointPlayer2 + 0);
                }

                if (palyers == player2)
                {

                    if (pointPlayer1 == 0)
                    {
                        tenisVieModel.player1Id = 1;
                        tenisVieModel.player1Name = "PLAYER 1";
                        tenisVieModel.player1Point = 0;
                    }

                    var pointWin = Services.Point.getPointWin(pointPlayer2);
                    if (pointWin.poinWin == 3)
                    {
                        if (tenisVieModel.player1Point == 0)
                        {
                            tenisVieModel.resultPoint = winnj2;
                            return tenisVieModel;
                        } else
                        {
                            tenisVieModel.resultPoint = "THE GAME IS OVER";
                            return tenisVieModel;
                        }
                    }
                    var pointPlayer = Services.Point.getPointPlayer(pointWin.poinWin + 1);

                    tenisVieModel.player2Id = 2;
                    tenisVieModel.player2Name = "PLAYER 2";
                    tenisVieModel.player2Point = (pointPlayer.poinPlay);

                    tenisVieModel.player1Point = (pointPlayer1 + 0);
                }

                tenisVieModel.resultPoint = tenisVieModel.player1Point + " - " + tenisVieModel.player2Point;

                if (tenisVieModel.player1Point == 40 && tenisVieModel.player2Point == 40)
                {
                    tenisVieModel.resultPoint = deuce;
                }
            }

            if (tenisVieModel.consecutivePointPlayer2 == tenisVieModel.consecutivePointPlayer1 && tenisVieModel.consecutivePointPlayer1 != 0)
            {
                tenisVieModel.resultPoint = deuce;
                tenisVieModel.consecutivePointPlayer2 = 0;
                tenisVieModel.consecutivePointPlayer1 = 0;
            }

            return tenisVieModel;
        }
    }
}