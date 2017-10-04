using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TankBattle;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace TankBattleTestSuite
{
    class RequirementException : Exception
    {
        public RequirementException()
        {
        }

        public RequirementException(string message) : base(message)
        {
        }

        public RequirementException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    class Test
    {
        #region Testing Code

        private delegate bool TestCase();

        private static string ErrorDescription = null;

        private static void SetErrorDescription(string desc)
        {
            ErrorDescription = desc;
        }

        private static bool FloatEquals(float a, float b)
        {
            if (Math.Abs(a - b) < 0.01) return true;
            return false;
        }

        private static Dictionary<string, string> unitTestResults = new Dictionary<string, string>();

        private static void Passed(string name, string comment)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[passed] ");
            Console.ResetColor();
            Console.Write("{0}", name);
            if (comment != "")
            {
                Console.Write(": {0}", comment);
            }
            if (ErrorDescription != null)
            {
                throw new Exception("ErrorDescription found for passing test case");
            }
            Console.WriteLine();
        }
        private static void Failed(string name, string comment)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[failed] ");
            Console.ResetColor();
            Console.Write("{0}", name);
            if (comment != "")
            {
                Console.Write(": {0}", comment);
            }
            if (ErrorDescription != null)
            {
                Console.Write("\n{0}", ErrorDescription);
                ErrorDescription = null;
            }
            Console.WriteLine();
        }
        private static void FailedToMeetRequirement(string name, string comment)
        {
            Console.Write("[      ] ");
            Console.Write("{0}", name);
            if (comment != "")
            {
                Console.Write(": ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("{0}", comment);
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        private static void DoTest(TestCase test)
        {
            // Have we already completed this test?
            if (unitTestResults.ContainsKey(test.Method.ToString()))
            {
                return;
            }

            bool passed = false;
            bool metRequirement = true;
            string exception = "";
            try
            {
                passed = test();
            }
            catch (RequirementException e)
            {
                metRequirement = false;
                exception = e.Message;
            }
            catch (Exception e)
            {
                exception = e.GetType().ToString();
            }

            string className = test.Method.ToString().Replace("Boolean Test", "").Split('0')[0];
            string fnName = test.Method.ToString().Split('0')[1];

            if (metRequirement)
            {
                if (passed)
                {
                    unitTestResults[test.Method.ToString()] = "Passed";
                    Passed(string.Format("{0}.{1}", className, fnName), exception);
                }
                else
                {
                    unitTestResults[test.Method.ToString()] = "Failed";
                    Failed(string.Format("{0}.{1}", className, fnName), exception);
                }
            }
            else
            {
                unitTestResults[test.Method.ToString()] = "Failed";
                FailedToMeetRequirement(string.Format("{0}.{1}", className, fnName), exception);
            }
            Cleanup();
        }

        private static Stack<string> errorDescriptionStack = new Stack<string>();


        private static void Requires(TestCase test)
        {
            string result;
            bool wasTested = unitTestResults.TryGetValue(test.Method.ToString(), out result);

            if (!wasTested)
            {
                // Push the error description onto the stack (only thing that can change, not that it should)
                errorDescriptionStack.Push(ErrorDescription);

                // Do the test
                DoTest(test);

                // Pop the description off
                ErrorDescription = errorDescriptionStack.Pop();

                // Get the proper result for out
                wasTested = unitTestResults.TryGetValue(test.Method.ToString(), out result);

                if (!wasTested)
                {
                    throw new Exception("This should never happen");
                }
            }

            if (result == "Failed")
            {
                string className = test.Method.ToString().Replace("Boolean Test", "").Split('0')[0];
                string fnName = test.Method.ToString().Split('0')[1];

                throw new RequirementException(string.Format("-> {0}.{1}", className, fnName));
            }
            else if (result == "Passed")
            {
                return;
            }
            else
            {
                throw new Exception("This should never happen");
            }

        }

        #endregion

        #region Test Cases
        private static Gameplay InitialiseGame()
        {
            Requires(TestGameplay0Gameplay);
            Requires(TestTankModel0GetTank);
            Requires(TestOpponent0HumanOpponent);
            Requires(TestGameplay0SetPlayer);

            Gameplay game = new Gameplay(2, 1);
            TankModel tank = TankModel.GetTank(1);
            Opponent player1 = new HumanOpponent("player1", tank, Color.Orange);
            Opponent player2 = new HumanOpponent("player2", tank, Color.Purple);
            game.SetPlayer(1, player1);
            game.SetPlayer(2, player2);
            return game;
        }
        private static void Cleanup()
        {
            while (Application.OpenForms.Count > 0)
            {
                Application.OpenForms[0].Dispose();
            }
        }
        private static bool TestGameplay0Gameplay()
        {
            Gameplay game = new Gameplay(2, 1);
            return true;
        }
        private static bool TestGameplay0PlayerCount()
        {
            Requires(TestGameplay0Gameplay);

            Gameplay game = new Gameplay(2, 1);
            return game.PlayerCount() == 2;
        }
        private static bool TestGameplay0GetTotalRounds()
        {
            Requires(TestGameplay0Gameplay);

            Gameplay game = new Gameplay(3, 5);
            return game.GetTotalRounds() == 5;
        }
        private static bool TestGameplay0SetPlayer()
        {
            Requires(TestGameplay0Gameplay);
            Requires(TestTankModel0GetTank);

            Gameplay game = new Gameplay(2, 1);
            TankModel tank = TankModel.GetTank(1);
            Opponent player = new HumanOpponent("playerName", tank, Color.Orange);
            game.SetPlayer(1, player);
            return true;
        }
        private static bool TestGameplay0GetPlayerNumber()
        {
            Requires(TestGameplay0Gameplay);
            Requires(TestTankModel0GetTank);
            Requires(TestOpponent0HumanOpponent);

            Gameplay game = new Gameplay(2, 1);
            TankModel tank = TankModel.GetTank(1);
            Opponent player = new HumanOpponent("playerName", tank, Color.Orange);
            game.SetPlayer(1, player);
            return game.GetPlayerNumber(1) == player;
        }
        private static bool TestGameplay0GetTankColour()
        {
            Color[] arrayOfColours = new Color[8];
            for (int i = 0; i < 8; i++)
            {
                arrayOfColours[i] = Gameplay.GetTankColour(i + 1);
                for (int j = 0; j < i; j++)
                {
                    if (arrayOfColours[j] == arrayOfColours[i]) return false;
                }
            }
            return true;
        }
        private static bool TestGameplay0CalculatePlayerPositions()
        {
            int[] positions = Gameplay.CalculatePlayerPositions(8);
            for (int i = 0; i < 8; i++)
            {
                if (positions[i] < 0) return false;
                if (positions[i] > 160) return false;
                for (int j = 0; j < i; j++)
                {
                    if (positions[j] == positions[i]) return false;
                }
            }
            return true;
        }
        private static bool TestGameplay0Shuffle()
        {
            int[] ar = new int[100];
            for (int i = 0; i < 100; i++)
            {
                ar[i] = i;
            }
            Gameplay.Shuffle(ar);
            for (int i = 0; i < 100; i++)
            {
                if (ar[i] != i)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool TestGameplay0NewGame()
        {
            Gameplay game = InitialiseGame();
            game.NewGame();

            foreach (Form f in Application.OpenForms)
            {
                if (f is GameplayForm)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool TestGameplay0GetLevel()
        {
            Requires(TestTerrain0Terrain);
            Gameplay game = InitialiseGame();
            game.NewGame();
            Terrain battlefield = game.GetLevel();
            if (battlefield != null) return true;

            return false;
        }
        private static bool TestGameplay0GetCurrentGameplayTank()
        {
            Requires(TestGameplay0Gameplay);
            Requires(TestTankModel0GetTank);
            Requires(TestOpponent0HumanOpponent);
            Requires(TestGameplay0SetPlayer);
            Requires(TestControlledTank0GetPlayerNumber);

            Gameplay game = new Gameplay(2, 1);
            TankModel tank = TankModel.GetTank(1);
            Opponent player1 = new HumanOpponent("player1", tank, Color.Orange);
            Opponent player2 = new HumanOpponent("player2", tank, Color.Purple);
            game.SetPlayer(1, player1);
            game.SetPlayer(2, player2);

            game.NewGame();
            ControlledTank ptank = game.GetCurrentGameplayTank();
            if (ptank.GetPlayerNumber() != player1 && ptank.GetPlayerNumber() != player2)
            {
                return false;
            }
            if (ptank.GetTank() != tank)
            {
                return false;
            }

            return true;
        }

        private static bool TestTankModel0GetTank()
        {
            TankModel tank = TankModel.GetTank(1);
            if (tank != null) return true;
            else return false;
        }
        private static bool TestTankModel0DisplayTank()
        {
            Requires(TestTankModel0GetTank);
            TankModel tank = TankModel.GetTank(1);

            int[,] tankGraphic = tank.DisplayTank(45);
            if (tankGraphic.GetLength(0) != 12) return false;
            if (tankGraphic.GetLength(1) != 16) return false;
            // We don't really care what the tank looks like, but the 45 degree tank
            // should at least look different to the -45 degree tank
            int[,] tankGraphic2 = tank.DisplayTank(-45);
            for (int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (tankGraphic2[y, x] != tankGraphic[y, x])
                    {
                        return true;
                    }
                }
            }

            SetErrorDescription("Tank with turret at -45 degrees looks the same as tank with turret at 45 degrees");

            return false;
        }
        private static void DisplayLine(int[,] array)
        {
            string report = "";
            report += "A line drawn from 3,0 to 0,3 on a 4x4 array should look like this:\n";
            report += "0001\n";
            report += "0010\n";
            report += "0100\n";
            report += "1000\n";
            report += "The one produced by TankModel.DrawLine() looks like this:\n";
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    report += array[y, x] == 1 ? "1" : "0";
                }
                report += "\n";
            }
            SetErrorDescription(report);
        }
        private static bool TestTankModel0DrawLine()
        {
            int[,] ar = new int[,] { { 0, 0, 0, 0 },
                                     { 0, 0, 0, 0 },
                                     { 0, 0, 0, 0 },
                                     { 0, 0, 0, 0 } };
            TankModel.DrawLine(ar, 3, 0, 0, 3);

            // Ideally, the line we want to see here is:
            // 0001
            // 0010
            // 0100
            // 1000

            // However, as we aren't that picky, as long as they have a 1 in every row and column
            // and nothing in the top-left and bottom-right corners

            int[] rows = new int[4];
            int[] cols = new int[4];
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (ar[y, x] == 1)
                    {
                        rows[y] = 1;
                        cols[x] = 1;
                    }
                    else if (ar[y, x] > 1 || ar[y, x] < 0)
                    {
                        // Only values 0 and 1 are permitted
                        SetErrorDescription(string.Format("Somehow the number {0} got into the array.", ar[y, x]));
                        return false;
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (rows[i] == 0)
                {
                    DisplayLine(ar);
                    return false;
                }
                if (cols[i] == 0)
                {
                    DisplayLine(ar);
                    return false;
                }
            }
            if (ar[0, 0] == 1)
            {
                DisplayLine(ar);
                return false;
            }
            if (ar[3, 3] == 1)
            {
                DisplayLine(ar);
                return false;
            }

            return true;
        }
        private static bool TestTankModel0GetArmour()
        {
            Requires(TestTankModel0GetTank);
            // As long as it's > 0 we're happy
            TankModel tank = TankModel.GetTank(1);
            if (tank.GetArmour() > 0) return true;
            return false;
        }
        private static bool TestTankModel0WeaponList()
        {
            Requires(TestTankModel0GetTank);
            // As long as there's at least one result and it's not null / a blank string, we're happy
            TankModel tank = TankModel.GetTank(1);
            if (tank.WeaponList().Length == 0) return false;
            if (tank.WeaponList()[0] == null) return false;
            if (tank.WeaponList()[0] == "") return false;
            return true;
        }

        private static Opponent CreateTestingPlayer()
        {
            Requires(TestTankModel0GetTank);
            Requires(TestOpponent0HumanOpponent);

            TankModel tank = TankModel.GetTank(1);
            Opponent player = new HumanOpponent("player1", tank, Color.Aquamarine);
            return player;
        }

        private static bool TestOpponent0HumanOpponent()
        {
            Requires(TestTankModel0GetTank);

            TankModel tank = TankModel.GetTank(1);
            Opponent player = new HumanOpponent("player1", tank, Color.Aquamarine);
            if (player != null) return true;
            return false;
        }
        private static bool TestOpponent0GetTank()
        {
            Requires(TestTankModel0GetTank);
            Requires(TestOpponent0HumanOpponent);

            TankModel tank = TankModel.GetTank(1);
            Opponent p = new HumanOpponent("player1", tank, Color.Aquamarine);
            if (p.GetTank() == tank) return true;
            return false;
        }
        private static bool TestOpponent0Name()
        {
            Requires(TestTankModel0GetTank);
            Requires(TestOpponent0HumanOpponent);

            const string PLAYER_NAME = "kfdsahskfdajh";
            TankModel tank = TankModel.GetTank(1);
            Opponent p = new HumanOpponent(PLAYER_NAME, tank, Color.Aquamarine);
            if (p.Name() == PLAYER_NAME) return true;
            return false;
        }
        private static bool TestOpponent0GetColour()
        {
            Requires(TestTankModel0GetTank);
            Requires(TestOpponent0HumanOpponent);

            Color playerColour = Color.Chartreuse;
            TankModel tank = TankModel.GetTank(1);
            Opponent p = new HumanOpponent("player1", tank, playerColour);
            if (p.GetColour() == playerColour) return true;
            return false;
        }
        private static bool TestOpponent0AddScore()
        {
            Opponent p = CreateTestingPlayer();
            p.AddScore();
            return true;
        }
        private static bool TestOpponent0GetScore()
        {
            Requires(TestOpponent0AddScore);

            Opponent p = CreateTestingPlayer();
            int wins = p.GetScore();
            p.AddScore();
            if (p.GetScore() == wins + 1) return true;
            return false;
        }
        private static bool TestHumanOpponent0StartRound()
        {
            Opponent p = CreateTestingPlayer();
            p.StartRound();
            return true;
        }
        private static bool TestHumanOpponent0BeginTurn()
        {
            Requires(TestGameplay0NewGame);
            Requires(TestGameplay0GetPlayerNumber);
            Gameplay game = InitialiseGame();

            game.NewGame();

            // Find the gameplay form
            GameplayForm gameplayForm = null;
            foreach (Form f in Application.OpenForms)
            {
                if (f is GameplayForm)
                {
                    gameplayForm = f as GameplayForm;
                }
            }
            if (gameplayForm == null)
            {
                SetErrorDescription("Gameplay form was not created by Gameplay.NewGame()");
                return false;
            }

            // Find the control panel
            Panel controlPanel = null;
            foreach (Control c in gameplayForm.Controls)
            {
                if (c is Panel)
                {
                    foreach (Control cc in c.Controls)
                    {
                        if (cc is NumericUpDown || cc is Label || cc is TrackBar)
                        {
                            controlPanel = c as Panel;
                        }
                    }
                }
            }

            if (controlPanel == null)
            {
                SetErrorDescription("Control panel was not found in GameplayForm");
                return false;
            }

            // Disable the control panel to check that NewTurn enables it
            controlPanel.Enabled = false;

            game.GetPlayerNumber(1).BeginTurn(gameplayForm, game);

            if (!controlPanel.Enabled)
            {
                SetErrorDescription("Control panel is still disabled after HumanPlayer.NewTurn()");
                return false;
            }
            return true;

        }
        private static bool TestHumanOpponent0ProjectileHitPos()
        {
            Opponent p = CreateTestingPlayer();
            p.ProjectileHitPos(0, 0);
            return true;
        }

        private static bool TestControlledTank0ControlledTank()
        {
            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);
            return true;
        }
        private static bool TestControlledTank0GetPlayerNumber()
        {
            Requires(TestControlledTank0ControlledTank);
            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);
            if (playerTank.GetPlayerNumber() == p) return true;
            return false;
        }
        private static bool TestControlledTank0GetTank()
        {
            Requires(TestControlledTank0ControlledTank);
            Requires(TestOpponent0GetTank);
            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);
            if (playerTank.GetTank() == playerTank.GetPlayerNumber().GetTank()) return true;
            return false;
        }
        private static bool TestControlledTank0GetAim()
        {
            Requires(TestControlledTank0ControlledTank);
            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);
            float angle = playerTank.GetAim();
            if (angle >= -90 && angle <= 90) return true;
            return false;
        }
        private static bool TestControlledTank0SetAimingAngle()
        {
            Requires(TestControlledTank0ControlledTank);
            Requires(TestControlledTank0GetAim);
            float angle = 75;
            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);
            playerTank.SetAimingAngle(angle);
            if (FloatEquals(playerTank.GetAim(), angle)) return true;
            return false;
        }
        private static bool TestControlledTank0GetCurrentPower()
        {
            Requires(TestControlledTank0ControlledTank);
            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);

            playerTank.GetCurrentPower();
            return true;
        }
        private static bool TestControlledTank0SetPower()
        {
            Requires(TestControlledTank0ControlledTank);
            Requires(TestControlledTank0GetCurrentPower);
            int power = 65;
            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);
            playerTank.SetPower(power);
            if (playerTank.GetCurrentPower() == power) return true;
            return false;
        }
        private static bool TestControlledTank0GetWeaponIndex()
        {
            Requires(TestControlledTank0ControlledTank);

            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);

            playerTank.GetWeaponIndex();
            return true;
        }
        private static bool TestControlledTank0SetWeaponIndex()
        {
            Requires(TestControlledTank0ControlledTank);
            Requires(TestControlledTank0GetWeaponIndex);
            int weapon = 3;
            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);
            playerTank.SetWeaponIndex(weapon);
            if (playerTank.GetWeaponIndex() == weapon) return true;
            return false;
        }
        private static bool TestControlledTank0Draw()
        {
            Requires(TestControlledTank0ControlledTank);
            Size bitmapSize = new Size(640, 480);
            Bitmap image = new Bitmap(bitmapSize.Width, bitmapSize.Height);
            Graphics graphics = Graphics.FromImage(image);
            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);
            playerTank.Draw(graphics, bitmapSize);
            graphics.Dispose();

            for (int y = 0; y < bitmapSize.Height; y++)
            {
                for (int x = 0; x < bitmapSize.Width; x++)
                {
                    if (image.GetPixel(x, y) != image.GetPixel(0, 0))
                    {
                        // Something changed in the image, and that's good enough for me
                        return true;
                    }
                }
            }
            SetErrorDescription("Nothing was drawn.");
            return false;
        }
        private static bool TestControlledTank0GetX()
        {
            Requires(TestControlledTank0ControlledTank);

            Opponent p = CreateTestingPlayer();
            int x = 73;
            int y = 28;
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, x, y, game);
            if (playerTank.GetX() == x) return true;
            return false;
        }
        private static bool TestControlledTank0GetYPos()
        {
            Requires(TestControlledTank0ControlledTank);

            Opponent p = CreateTestingPlayer();
            int x = 73;
            int y = 28;
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, x, y, game);
            if (playerTank.GetYPos() == y) return true;
            return false;
        }
        private static bool TestControlledTank0Attack()
        {
            Requires(TestControlledTank0ControlledTank);

            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);
            playerTank.Attack();
            return true;
        }
        private static bool TestControlledTank0InflictDamage()
        {
            Requires(TestControlledTank0ControlledTank);
            Opponent p = CreateTestingPlayer();

            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);
            playerTank.InflictDamage(10);
            return true;
        }
        private static bool TestControlledTank0Exists()
        {
            Requires(TestControlledTank0ControlledTank);
            Requires(TestControlledTank0InflictDamage);

            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            ControlledTank playerTank = new ControlledTank(p, 32, 32, game);
            if (!playerTank.Exists()) return false;
            playerTank.InflictDamage(playerTank.GetTank().GetArmour());
            if (playerTank.Exists()) return false;
            return true;
        }
        private static bool TestControlledTank0Gravity()
        {
            Requires(TestGameplay0GetLevel);
            Requires(TestTerrain0DestroyGround);
            Requires(TestControlledTank0ControlledTank);
            Requires(TestControlledTank0InflictDamage);
            Requires(TestControlledTank0Exists);
            Requires(TestControlledTank0GetTank);
            Requires(TestTankModel0GetArmour);

            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            game.NewGame();
            // Unfortunately we need to rely on DestroyTerrain() to get rid of any terrain that may be in the way
            game.GetLevel().DestroyGround(Terrain.WIDTH / 2.0f, Terrain.HEIGHT / 2.0f, 20);
            ControlledTank playerTank = new ControlledTank(p, Terrain.WIDTH / 2, Terrain.HEIGHT / 2, game);
            int oldX = playerTank.GetX();
            int oldY = playerTank.GetYPos();

            playerTank.Gravity();

            if (playerTank.GetX() != oldX)
            {
                SetErrorDescription("Caused X coordinate to change.");
                return false;
            }
            if (playerTank.GetYPos() != oldY + 1)
            {
                SetErrorDescription("Did not cause Y coordinate to increase by 1.");
                return false;
            }

            int initialArmour = playerTank.GetTank().GetArmour();
            // The tank should have lost 1 armour from falling 1 tile already, so do
            // (initialArmour - 2) damage to the tank then drop it again. That should kill it.

            if (!playerTank.Exists())
            {
                SetErrorDescription("Tank died before we could check that fall damage worked properly");
                return false;
            }
            playerTank.InflictDamage(initialArmour - 2);
            if (!playerTank.Exists())
            {
                SetErrorDescription("Tank died before we could check that fall damage worked properly");
                return false;
            }
            playerTank.Gravity();
            if (playerTank.Exists())
            {
                SetErrorDescription("Tank survived despite taking enough falling damage to destroy it");
                return false;
            }

            return true;
        }
        private static bool TestTerrain0Terrain()
        {
            Terrain battlefield = new Terrain();
            return true;
        }
        private static bool TestTerrain0IsTileAt()
        {
            Requires(TestTerrain0Terrain);

            bool foundTrue = false;
            bool foundFalse = false;
            Terrain battlefield = new Terrain();
            for (int y = 0; y < Terrain.HEIGHT; y++)
            {
                for (int x = 0; x < Terrain.WIDTH; x++)
                {
                    if (battlefield.IsTileAt(x, y))
                    {
                        foundTrue = true;
                    }
                    else
                    {
                        foundFalse = true;
                    }
                }
            }

            if (!foundTrue)
            {
                SetErrorDescription("IsTileAt() did not return true for any tile.");
                return false;
            }

            if (!foundFalse)
            {
                SetErrorDescription("IsTileAt() did not return false for any tile.");
                return false;
            }

            return true;
        }
        private static bool TestTerrain0CheckTankCollision()
        {
            Requires(TestTerrain0Terrain);
            Requires(TestTerrain0IsTileAt);

            Terrain battlefield = new Terrain();
            for (int y = 0; y <= Terrain.HEIGHT - TankModel.HEIGHT; y++)
            {
                for (int x = 0; x <= Terrain.WIDTH - TankModel.WIDTH; x++)
                {
                    int colTiles = 0;
                    for (int iy = 0; iy < TankModel.HEIGHT; iy++)
                    {
                        for (int ix = 0; ix < TankModel.WIDTH; ix++)
                        {

                            if (battlefield.IsTileAt(x + ix, y + iy))
                            {
                                colTiles++;
                            }
                        }
                    }
                    if (colTiles == 0)
                    {
                        if (battlefield.CheckTankCollision(x, y))
                        {
                            SetErrorDescription("Found collision where there shouldn't be one");
                            return false;
                        }
                    }
                    else
                    {
                        if (!battlefield.CheckTankCollision(x, y))
                        {
                            SetErrorDescription("Didn't find collision where there should be one");
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        private static bool TestTerrain0TankYPosition()
        {
            Requires(TestTerrain0Terrain);
            Requires(TestTerrain0IsTileAt);

            Terrain battlefield = new Terrain();
            for (int x = 0; x <= Terrain.WIDTH - TankModel.WIDTH; x++)
            {
                int lowestValid = 0;
                for (int y = 0; y <= Terrain.HEIGHT - TankModel.HEIGHT; y++)
                {
                    int colTiles = 0;
                    for (int iy = 0; iy < TankModel.HEIGHT; iy++)
                    {
                        for (int ix = 0; ix < TankModel.WIDTH; ix++)
                        {

                            if (battlefield.IsTileAt(x + ix, y + iy))
                            {
                                colTiles++;
                            }
                        }
                    }
                    if (colTiles == 0)
                    {
                        lowestValid = y;
                    }
                }

                int placedY = battlefield.TankYPosition(x);
                if (placedY != lowestValid)
                {
                    SetErrorDescription(string.Format("Tank was placed at {0},{1} when it should have been placed at {0},{2}", x, placedY, lowestValid));
                    return false;
                }
            }
            return true;
        }
        private static bool TestTerrain0DestroyGround()
        {
            Requires(TestTerrain0Terrain);
            Requires(TestTerrain0IsTileAt);

            Terrain battlefield = new Terrain();
            for (int y = 0; y < Terrain.HEIGHT; y++)
            {
                for (int x = 0; x < Terrain.WIDTH; x++)
                {
                    if (battlefield.IsTileAt(x, y))
                    {
                        battlefield.DestroyGround(x, y, 0.5f);
                        if (battlefield.IsTileAt(x, y))
                        {
                            SetErrorDescription("Attempted to destroy terrain but it still exists");
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            SetErrorDescription("Did not find any terrain to destroy");
            return false;
        }
        private static bool TestTerrain0Gravity()
        {
            Requires(TestTerrain0Terrain);
            Requires(TestTerrain0IsTileAt);
            Requires(TestTerrain0DestroyGround);

            Terrain battlefield = new Terrain();
            for (int x = 0; x < Terrain.WIDTH; x++)
            {
                if (battlefield.IsTileAt(x, Terrain.HEIGHT - 1))
                {
                    if (battlefield.IsTileAt(x, Terrain.HEIGHT - 2))
                    {
                        // Seek up and find the first non-set tile
                        for (int y = Terrain.HEIGHT - 2; y >= 0; y--)
                        {
                            if (!battlefield.IsTileAt(x, y))
                            {
                                // Do a gravity step and make sure it doesn't slip down
                                battlefield.Gravity();
                                if (!battlefield.IsTileAt(x, y + 1))
                                {
                                    SetErrorDescription("Moved down terrain even though there was no room");
                                    return false;
                                }

                                // Destroy the bottom-most tile
                                battlefield.DestroyGround(x, Terrain.HEIGHT - 1, 0.5f);

                                // Do a gravity step and make sure it does slip down
                                battlefield.Gravity();

                                if (battlefield.IsTileAt(x, y + 1))
                                {
                                    SetErrorDescription("Terrain didn't fall");
                                    return false;
                                }

                                // Otherwise this seems to have worked
                                return true;
                            }
                        }


                    }
                }
            }
            SetErrorDescription("Did not find any appropriate terrain to test");
            return false;
        }
        private static bool TestWeaponEffect0RecordCurrentGame()
        {
            Requires(TestBlast0Blast);
            Requires(TestGameplay0Gameplay);

            WeaponEffect weaponEffect = new Blast(1, 1, 1);
            Gameplay game = new Gameplay(2, 1);
            weaponEffect.RecordCurrentGame(game);
            return true;
        }
        private static bool TestShell0Shell()
        {
            Requires(TestBlast0Blast);
            Opponent player = CreateTestingPlayer();
            Blast explosion = new Blast(1, 1, 1);
            Shell projectile = new Shell(25, 25, 45, 30, 0.02f, explosion, player);
            return true;
        }
        private static bool TestShell0Process()
        {
            Requires(TestGameplay0NewGame);
            Requires(TestBlast0Blast);
            Requires(TestShell0Shell);
            Requires(TestWeaponEffect0RecordCurrentGame);
            Gameplay game = InitialiseGame();
            game.NewGame();
            Opponent player = game.GetPlayerNumber(1);
            Blast explosion = new Blast(1, 1, 1);

            Shell projectile = new Shell(25, 25, 45, 100, 0.01f, explosion, player);
            projectile.RecordCurrentGame(game);
            projectile.Process();

            // We can't really test this one without a substantial framework,
            // so we just call it and hope that everything works out

            return true;
        }
        private static bool TestShell0Draw()
        {
            Requires(TestGameplay0NewGame);
            Requires(TestGameplay0GetPlayerNumber);
            Requires(TestBlast0Blast);
            Requires(TestShell0Shell);
            Requires(TestWeaponEffect0RecordCurrentGame);

            Size bitmapSize = new Size(640, 480);
            Bitmap image = new Bitmap(bitmapSize.Width, bitmapSize.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(Color.Black); // Blacken out the image so we can see the projectile
            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            game.NewGame();
            Opponent player = game.GetPlayerNumber(1);
            Blast explosion = new Blast(1, 1, 1);

            Shell projectile = new Shell(25, 25, 45, 100, 0.01f, explosion, player);
            projectile.RecordCurrentGame(game);
            projectile.Draw(graphics, bitmapSize);
            graphics.Dispose();

            for (int y = 0; y < bitmapSize.Height; y++)
            {
                for (int x = 0; x < bitmapSize.Width; x++)
                {
                    if (image.GetPixel(x, y) != image.GetPixel(0, 0))
                    {
                        // Something changed in the image, and that's good enough for me
                        return true;
                    }
                }
            }
            SetErrorDescription("Nothing was drawn.");
            return false;
        }
        private static bool TestBlast0Blast()
        {
            Opponent player = CreateTestingPlayer();
            Blast explosion = new Blast(1, 1, 1);

            return true;
        }
        private static bool TestBlast0Explode()
        {
            Requires(TestBlast0Blast);
            Requires(TestWeaponEffect0RecordCurrentGame);
            Requires(TestGameplay0GetPlayerNumber);
            Requires(TestGameplay0NewGame);

            Gameplay game = InitialiseGame();
            game.NewGame();
            Opponent player = game.GetPlayerNumber(1);
            Blast explosion = new Blast(1, 1, 1);
            explosion.RecordCurrentGame(game);
            explosion.Explode(25, 25);

            return true;
        }
        private static bool TestBlast0Process()
        {
            Requires(TestBlast0Blast);
            Requires(TestWeaponEffect0RecordCurrentGame);
            Requires(TestGameplay0GetPlayerNumber);
            Requires(TestGameplay0NewGame);
            Requires(TestBlast0Explode);

            Gameplay game = InitialiseGame();
            game.NewGame();
            Opponent player = game.GetPlayerNumber(1);
            Blast explosion = new Blast(1, 1, 1);
            explosion.RecordCurrentGame(game);
            explosion.Explode(25, 25);
            explosion.Process();

            // Again, we can't really test this one without a full framework

            return true;
        }
        private static bool TestBlast0Draw()
        {
            Requires(TestBlast0Blast);
            Requires(TestWeaponEffect0RecordCurrentGame);
            Requires(TestGameplay0GetPlayerNumber);
            Requires(TestGameplay0NewGame);
            Requires(TestBlast0Explode);
            Requires(TestBlast0Process);

            Size bitmapSize = new Size(640, 480);
            Bitmap image = new Bitmap(bitmapSize.Width, bitmapSize.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(Color.Black); // Blacken out the image so we can see the explosion
            Opponent p = CreateTestingPlayer();
            Gameplay game = InitialiseGame();
            game.NewGame();
            Opponent player = game.GetPlayerNumber(1);
            Blast explosion = new Blast(10, 10, 10);
            explosion.RecordCurrentGame(game);
            explosion.Explode(25, 25);
            // Step it for a bit so we can be sure the explosion is visible
            for (int i = 0; i < 10; i++)
            {
                explosion.Process();
            }
            explosion.Draw(graphics, bitmapSize);

            for (int y = 0; y < bitmapSize.Height; y++)
            {
                for (int x = 0; x < bitmapSize.Width; x++)
                {
                    if (image.GetPixel(x, y) != image.GetPixel(0, 0))
                    {
                        // Something changed in the image, and that's good enough for me
                        return true;
                    }
                }
            }
            SetErrorDescription("Nothing was drawn.");
            return false;
        }

        private static GameplayForm InitialiseGameplayForm(out NumericUpDown angleCtrl, out TrackBar powerCtrl, out Button fireCtrl, out Panel controlPanel, out ListBox weaponSelect)
        {
            Requires(TestGameplay0NewGame);

            Gameplay game = InitialiseGame();

            angleCtrl = null;
            powerCtrl = null;
            fireCtrl = null;
            controlPanel = null;
            weaponSelect = null;

            game.NewGame();
            GameplayForm gameplayForm = null;
            foreach (Form f in Application.OpenForms)
            {
                if (f is GameplayForm)
                {
                    gameplayForm = f as GameplayForm;
                }
            }
            if (gameplayForm == null)
            {
                SetErrorDescription("Gameplay.NewGame() did not create a GameplayForm and that is the only way GameplayForm can be tested");
                return null;
            }

            bool foundDisplayPanel = false;
            bool foundControlPanel = false;

            foreach (Control c in gameplayForm.Controls)
            {
                // The only controls should be 2 panels
                if (c is Panel)
                {
                    // Is this the control panel or the display panel?
                    Panel p = c as Panel;

                    // The display panel will have 0 controls.
                    // The control panel will have separate, of which only a few are mandatory
                    int controlsFound = 0;
                    bool foundFire = false;
                    bool foundAngle = false;
                    bool foundAngleLabel = false;
                    bool foundPower = false;
                    bool foundPowerLabel = false;


                    foreach (Control pc in p.Controls)
                    {
                        controlsFound++;

                        // Mandatory controls for the control panel are:
                        // A 'Fire!' button
                        // A NumericUpDown for controlling the angle
                        // A TrackBar for controlling the power
                        // "Power:" and "Angle:" labels

                        if (pc is Label)
                        {
                            Label lbl = pc as Label;
                            if (lbl.Text.ToLower().Contains("angle"))
                            {
                                foundAngleLabel = true;
                            }
                            else
                            if (lbl.Text.ToLower().Contains("power"))
                            {
                                foundPowerLabel = true;
                            }
                        }
                        else
                        if (pc is Button)
                        {
                            Button btn = pc as Button;
                            if (btn.Text.ToLower().Contains("fire"))
                            {
                                foundFire = true;
                                fireCtrl = btn;
                            }
                        }
                        else
                        if (pc is TrackBar)
                        {
                            foundPower = true;
                            powerCtrl = pc as TrackBar;
                        }
                        else
                        if (pc is NumericUpDown)
                        {
                            foundAngle = true;
                            angleCtrl = pc as NumericUpDown;
                        }
                        else
                        if (pc is ListBox)
                        {
                            weaponSelect = pc as ListBox;
                        }
                    }

                    if (controlsFound == 0)
                    {
                        foundDisplayPanel = true;
                    }
                    else
                    {
                        if (!foundFire)
                        {
                            SetErrorDescription("Control panel lacks a \"Fire!\" button OR the display panel incorrectly contains controls");
                            return null;
                        }
                        else
                        if (!foundAngle)
                        {
                            SetErrorDescription("Control panel lacks an angle NumericUpDown OR the display panel incorrectly contains controls");
                            return null;
                        }
                        else
                        if (!foundPower)
                        {
                            SetErrorDescription("Control panel lacks a power TrackBar OR the display panel incorrectly contains controls");
                            return null;
                        }
                        else
                        if (!foundAngleLabel)
                        {
                            SetErrorDescription("Control panel lacks an \"Angle:\" label OR the display panel incorrectly contains controls");
                            return null;
                        }
                        else
                        if (!foundPowerLabel)
                        {
                            SetErrorDescription("Control panel lacks a \"Power:\" label OR the display panel incorrectly contains controls");
                            return null;
                        }

                        foundControlPanel = true;
                        controlPanel = p;
                    }

                }
                else
                {
                    SetErrorDescription(string.Format("Unexpected control ({0}) named \"{1}\" found in GameplayForm", c.GetType().FullName, c.Name));
                    return null;
                }
            }

            if (!foundDisplayPanel)
            {
                SetErrorDescription("No display panel found");
                return null;
            }
            if (!foundControlPanel)
            {
                SetErrorDescription("No control panel found");
                return null;
            }
            return gameplayForm;
        }

        private static bool TestGameplayForm0GameplayForm()
        {
            NumericUpDown angle;
            TrackBar power;
            Button fire;
            Panel controlPanel;
            ListBox weaponSelect;
            GameplayForm gameplayForm = InitialiseGameplayForm(out angle, out power, out fire, out controlPanel, out weaponSelect);

            if (gameplayForm == null) return false;

            return true;
        }
        private static bool TestGameplayForm0EnableTankButtons()
        {
            Requires(TestGameplayForm0GameplayForm);
            Gameplay game = InitialiseGame();
            game.NewGame();

            // Find the gameplay form
            GameplayForm gameplayForm = null;
            foreach (Form f in Application.OpenForms)
            {
                if (f is GameplayForm)
                {
                    gameplayForm = f as GameplayForm;
                }
            }
            if (gameplayForm == null)
            {
                SetErrorDescription("Gameplay form was not created by Gameplay.NewGame()");
                return false;
            }

            // Find the control panel
            Panel controlPanel = null;
            foreach (Control c in gameplayForm.Controls)
            {
                if (c is Panel)
                {
                    foreach (Control cc in c.Controls)
                    {
                        if (cc is NumericUpDown || cc is Label || cc is TrackBar)
                        {
                            controlPanel = c as Panel;
                        }
                    }
                }
            }

            if (controlPanel == null)
            {
                SetErrorDescription("Control panel was not found in GameplayForm");
                return false;
            }

            // Disable the control panel to check that EnableControlPanel enables it
            controlPanel.Enabled = false;

            gameplayForm.EnableTankButtons();

            if (!controlPanel.Enabled)
            {
                SetErrorDescription("Control panel is still disabled after GameplayForm.EnableTankButtons()");
                return false;
            }
            return true;

        }
        private static bool TestGameplayForm0SetAimingAngle()
        {
            Requires(TestGameplayForm0GameplayForm);
            NumericUpDown angle;
            TrackBar power;
            Button fire;
            Panel controlPanel;
            ListBox weaponSelect;
            GameplayForm gameplayForm = InitialiseGameplayForm(out angle, out power, out fire, out controlPanel, out weaponSelect);

            if (gameplayForm == null) return false;

            float testAngle = 27;

            gameplayForm.SetAimingAngle(testAngle);
            if (FloatEquals((float)angle.Value, testAngle)) return true;

            else
            {
                SetErrorDescription(string.Format("Attempted to set angle to {0} but angle is {1}", testAngle, (float)angle.Value));
                return false;
            }
        }
        private static bool TestGameplayForm0SetPower()
        {
            Requires(TestGameplayForm0GameplayForm);
            NumericUpDown angle;
            TrackBar power;
            Button fire;
            Panel controlPanel;
            ListBox weaponSelect;
            GameplayForm gameplayForm = InitialiseGameplayForm(out angle, out power, out fire, out controlPanel, out weaponSelect);

            if (gameplayForm == null) return false;

            int testPower = 71;

            gameplayForm.SetPower(testPower);
            if (power.Value == testPower) return true;

            else
            {
                SetErrorDescription(string.Format("Attempted to set power to {0} but power is {1}", testPower, power.Value));
                return false;
            }
        }
        private static bool TestGameplayForm0SetWeaponIndex()
        {
            Requires(TestGameplayForm0GameplayForm);
            NumericUpDown angle;
            TrackBar power;
            Button fire;
            Panel controlPanel;
            ListBox weaponSelect;
            GameplayForm gameplayForm = InitialiseGameplayForm(out angle, out power, out fire, out controlPanel, out weaponSelect);

            if (gameplayForm == null) return false;

            gameplayForm.SetWeaponIndex(0);

            // WeaponSelect is optional behaviour, so it's okay if it's not implemented here, as long as the method works.
            return true;
        }
        private static bool TestGameplayForm0Attack()
        {
            Requires(TestGameplayForm0GameplayForm);
            // This is something we can't really test properly without a proper framework, so for now we'll just click
            // the button and make sure it disables the control panel
            NumericUpDown angle;
            TrackBar power;
            Button fire;
            Panel controlPanel;
            ListBox weaponSelect;
            GameplayForm gameplayForm = InitialiseGameplayForm(out angle, out power, out fire, out controlPanel, out weaponSelect);

            controlPanel.Enabled = true;
            fire.PerformClick();
            if (controlPanel.Enabled)
            {
                SetErrorDescription("Control panel still enabled immediately after clicking fire button");
                return false;
            }

            return true;
        }
        private static void UnitTests()
        {
            DoTest(TestGameplay0Gameplay);
            DoTest(TestGameplay0PlayerCount);
            DoTest(TestGameplay0GetTotalRounds);
            DoTest(TestGameplay0SetPlayer);
            DoTest(TestGameplay0GetPlayerNumber);
            DoTest(TestGameplay0GetTankColour);
            DoTest(TestGameplay0CalculatePlayerPositions);
            DoTest(TestGameplay0Shuffle);
            DoTest(TestGameplay0NewGame);
            DoTest(TestGameplay0GetLevel);
            DoTest(TestGameplay0GetCurrentGameplayTank);
            DoTest(TestTankModel0GetTank);
            DoTest(TestTankModel0DisplayTank);
            DoTest(TestTankModel0DrawLine);
            DoTest(TestTankModel0GetArmour);
            DoTest(TestTankModel0WeaponList);
            DoTest(TestOpponent0HumanOpponent);
            DoTest(TestOpponent0GetTank);
            DoTest(TestOpponent0Name);
            DoTest(TestOpponent0GetColour);
            DoTest(TestOpponent0AddScore);
            DoTest(TestOpponent0GetScore);
            DoTest(TestHumanOpponent0StartRound);
            DoTest(TestHumanOpponent0BeginTurn);
            DoTest(TestHumanOpponent0ProjectileHitPos);
            DoTest(TestControlledTank0ControlledTank);
            DoTest(TestControlledTank0GetPlayerNumber);
            DoTest(TestControlledTank0GetTank);
            DoTest(TestControlledTank0GetAim);
            DoTest(TestControlledTank0SetAimingAngle);
            DoTest(TestControlledTank0GetCurrentPower);
            DoTest(TestControlledTank0SetPower);
            DoTest(TestControlledTank0GetWeaponIndex);
            DoTest(TestControlledTank0SetWeaponIndex);
            DoTest(TestControlledTank0Draw);
            DoTest(TestControlledTank0GetX);
            DoTest(TestControlledTank0GetYPos);
            DoTest(TestControlledTank0Attack);
            DoTest(TestControlledTank0InflictDamage);
            DoTest(TestControlledTank0Exists);
            DoTest(TestControlledTank0Gravity);
            DoTest(TestTerrain0Terrain);
            DoTest(TestTerrain0IsTileAt);
            DoTest(TestTerrain0CheckTankCollision);
            DoTest(TestTerrain0TankYPosition);
            DoTest(TestTerrain0DestroyGround);
            DoTest(TestTerrain0Gravity);
            DoTest(TestWeaponEffect0RecordCurrentGame);
            DoTest(TestShell0Shell);
            DoTest(TestShell0Process);
            DoTest(TestShell0Draw);
            DoTest(TestBlast0Blast);
            DoTest(TestBlast0Explode);
            DoTest(TestBlast0Process);
            DoTest(TestBlast0Draw);
            DoTest(TestGameplayForm0GameplayForm);
            DoTest(TestGameplayForm0EnableTankButtons);
            DoTest(TestGameplayForm0SetAimingAngle);
            DoTest(TestGameplayForm0SetPower);
            DoTest(TestGameplayForm0SetWeaponIndex);
            DoTest(TestGameplayForm0Attack);
        }
        
        #endregion
        
        #region CheckClasses

        private static bool CheckClasses()
        {
            string[] classNames = new string[] { "Program", "AIOpponent", "Terrain", "Blast", "GameplayForm", "Gameplay", "HumanOpponent", "Shell", "Opponent", "ControlledTank", "TankModel", "WeaponEffect" };
            string[][] classFields = new string[][] {
                new string[] { "Main" }, // Program
                new string[] { }, // AIOpponent
                new string[] { "IsTileAt","CheckTankCollision","TankYPosition","DestroyGround","Gravity","WIDTH","HEIGHT"}, // Terrain
                new string[] { "Explode" }, // Blast
                new string[] { "EnableTankButtons","SetAimingAngle","SetPower","SetWeaponIndex","Attack","InitRenderBuffer"}, // GameplayForm
                new string[] { "PlayerCount","GetRound","GetTotalRounds","SetPlayer","GetPlayerNumber","PlayerTank","GetTankColour","CalculatePlayerPositions","Shuffle","NewGame","BeginRound","GetLevel","DrawPlayers","GetCurrentGameplayTank","AddWeaponEffect","ProcessEffects","RenderEffects","EndEffect","CheckHitTank","InflictDamage","Gravity","TurnOver","RewardWinner","NextRound","GetWindSpeed"}, // Gameplay
                new string[] { }, // HumanOpponent
                new string[] { }, // Shell
                new string[] { "GetTank","Name","GetColour","AddScore","GetScore","StartRound","BeginTurn","ProjectileHitPos"}, // Opponent
                new string[] { "GetPlayerNumber","GetTank","GetAim","SetAimingAngle","GetCurrentPower","SetPower","GetWeaponIndex","SetWeaponIndex","Draw","GetX","GetYPos","Attack","InflictDamage","Exists","Gravity"}, // ControlledTank
                new string[] { "DisplayTank","DrawLine","CreateBitmap","GetArmour","WeaponList","FireWeapon","GetTank","WIDTH","HEIGHT","NUM_TANKS"}, // TankModel
                new string[] { "RecordCurrentGame","Process","Draw"} // WeaponEffect
            };

            Assembly assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine("Checking classes for public methods...");
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsPublic)
                {
                    if (type.Namespace != "TankBattle")
                    {
                        Console.WriteLine("Public type {0} is not in the TankBattle namespace.", type.FullName);
                        return false;
                    }
                    else
                    {
                        int typeIdx = -1;
                        for (int i = 0; i < classNames.Length; i++)
                        {
                            if (type.Name == classNames[i])
                            {
                                typeIdx = i;
                                classNames[typeIdx] = null;
                                break;
                            }
                        }
                        foreach (MemberInfo memberInfo in type.GetMembers())
                        {
                            string memberName = memberInfo.Name;
                            bool isInherited = false;
                            foreach (MemberInfo parentMemberInfo in type.BaseType.GetMembers())
                            {
                                if (memberInfo.Name == parentMemberInfo.Name)
                                {
                                    isInherited = true;
                                    break;
                                }
                            }
                            if (!isInherited)
                            {
                                if (typeIdx != -1)
                                {
                                    bool fieldFound = false;
                                    if (memberName[0] != '.')
                                    {
                                        foreach (string allowedFields in classFields[typeIdx])
                                        {
                                            if (memberName == allowedFields)
                                            {
                                                fieldFound = true;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        fieldFound = true;
                                    }
                                    if (!fieldFound)
                                    {
                                        Console.WriteLine("The public field \"{0}\" is not one of the authorised fields for the {1} class.\n", memberName, type.Name);
                                        Console.WriteLine("Remove it or change its access level.");
                                        return false;
                                    }
                                }
                            }
                        }
                    }

                    //Console.WriteLine("{0} passed.", type.FullName);
                }
            }
            for (int i = 0; i < classNames.Length; i++)
            {
                if (classNames[i] != null)
                {
                    Console.WriteLine("The class \"{0}\" is missing.", classNames[i]);
                    return false;
                }
            }
            Console.WriteLine("All public methods okay.");
            return true;
        }
        
        #endregion

        public static void Main()
        {
            if (CheckClasses())
            {
                UnitTests();

                int passed = 0;
                int failed = 0;
                foreach (string key in unitTestResults.Keys)
                {
                    if (unitTestResults[key] == "Passed")
                    {
                        passed++;
                    }
                    else
                    {
                        failed++;
                    }
                }

                Console.WriteLine("\n{0}/{1} unit tests passed", passed, passed + failed);
                if (failed == 0)
                {
                    Console.WriteLine("Starting up TankBattle...");
                    Program.Main();
                    return;
                }
            }

            Console.WriteLine("\nPress enter to exit.");
            Console.ReadLine();
        }
    }
}
