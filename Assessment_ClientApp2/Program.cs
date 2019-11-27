using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Assessment_ClientApp2
{

    // **************************************************
    //
    // Assessment: Client App 2.0
    // Author: Robert Parsons
    // Dated: 11/27/2019
    // Level (Novice, Apprentice, or Master): Mostly Master
    //
    // **************************************************    

    class Program
    {
        /// <summary>
        /// Main method - app starts here
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //
            // read monsters from data file
            //
            List<Monster> monsters = ReadFromDataFile();

            //
            // application flow
            //
            DisplayWelcomeScreen();
            DisplayMenuScreen(monsters);
            DisplayClosingScreen();
        }

        #region SCREEN DISPLAY METHODS

        /// <summary>
        /// SCREEN: display and process menu options
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayMenuScreen(List<Monster> monsters)
        {
            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) List All Monsters");
                Console.WriteLine("\tb) View Monster Detail");
                Console.WriteLine("\tc) Add Monster");
                Console.WriteLine("\td) Deactivate Monster");
                Console.WriteLine("\te) Update Monster");
                Console.WriteLine("\tf) Filter Monsters");
                Console.WriteLine("\tg) Save Monsters");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayAllMonsters(monsters);
                        break;

                    case "b":
                        DisplayViewMonsterDetail(monsters);
                        break;

                    case "c":
                        DisplayAddMonster(monsters);
                        break;

                    case "d":
                        DisplayDeleteMonster(monsters);
                        break;

                    case "e":
                        DisplayUpdateMonster(monsters);
                        break;

                    case "f":
                        DisplayFilterMonster(monsters);
                        break;

                    case "g":
                        DisplayWriteToDataFile(monsters);
                        break;
                        
                    case "q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a letter A-G or Q for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitApplication);
        }

        private static void DisplayFilterMonster(List<Monster> monsters)
        {
            List<Monster> filteredMonsters = new List<Monster>();
            bool validResponse = true;

            DisplayScreenHeader("Filter Monsters");
            //
            //add monsters with the selected attitude to a new list
            //
            Console.WriteLine("\tWhat would you like to filter by?");

            Console.WriteLine("\ta) Tribe");
            Console.WriteLine("\tb) Attitude");
            Console.WriteLine("\tc) Active");

            do
            {
                Console.Write("\t");
                string userResponse = Console.ReadLine();
                switch (userResponse)
                {
                    case ("a"):
                        {
                            int index = 0;
                            bool validTribe = false;
                            Console.WriteLine("\tWhat tribe do you wish to filter by?");
                            foreach (string tribe in Enum.GetNames(typeof(Monster.TribeState)))
                            {
                                if (tribe == "none")
                                { }
                                else
                                {
                                    Console.WriteLine($"\t{index}) {tribe}");
                                }
                                index++;
                            }
                            do
                            {
                                Console.Write("\t");
                                string userTribeResponse = Console.ReadLine().ToLower();
                                switch (userTribeResponse)
                                {
                                    case ("1"):
                                        {
                                            filteredMonsters = monsters.Where(m => m.Tribe == Monster.TribeState.mountain).ToList();
                                            filteredMonsters = filteredMonsters.OrderBy(m => m.Name).ToList();
                                            validTribe = true;
                                            break;
                                        }
                                    case ("2"):
                                        {
                                            filteredMonsters = monsters.Where(m => m.Tribe == Monster.TribeState.plain).ToList();
                                            filteredMonsters = filteredMonsters.OrderBy(m => m.Name).ToList();
                                            validTribe = true;
                                            break;
                                        }
                                                                                
                                    case ("3"):
                                        {
                                            filteredMonsters = monsters.Where(m => m.Tribe == Monster.TribeState.ocean).ToList();
                                            filteredMonsters = filteredMonsters.OrderBy(m => m.Name).ToList();
                                            validTribe = true;
                                            break;
                                        }

                                    case ("4"):
                                        {
                                            filteredMonsters = monsters.Where(m => m.Tribe == Monster.TribeState.desert).ToList();
                                            filteredMonsters = filteredMonsters.OrderBy(m => m.Name).ToList();
                                            validTribe = true;
                                            break;
                                        }

                                    case ("5"):
                                        {
                                            filteredMonsters = monsters.Where(m => m.Tribe == Monster.TribeState.underground).ToList();
                                            filteredMonsters = filteredMonsters.OrderBy(m => m.Name).ToList();
                                            validTribe = true;
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine("\tPlease enter a valid number.");
                                            break;
                                        }
                                            
                                }

                            } while (!validTribe);
                            break;
                        }
                    case ("b"):
                        {
                            int index = 0;
                            bool validAttitude = false;

                            Console.WriteLine("\tWhat attitude do you wish to filter by?");
                            foreach (string attitude in Enum.GetNames(typeof(Monster.EmotionalState)))
                            {
                                if (attitude == "none")
                                { }
                                else
                                {
                                    Console.WriteLine($"\t{index}) {attitude}");
                                }
                                index++;
                            }
                            do
                            {
                                Console.Write("\t");
                                string userEmotionResponse = Console.ReadLine().ToLower();
                                switch (userEmotionResponse)
                                {
                                    case ("1"):
                                        {
                                            filteredMonsters = monsters.Where(m => m.Attitude == Monster.EmotionalState.happy).ToList();
                                            filteredMonsters = filteredMonsters.OrderBy(m => m.Name).ToList();
                                            validAttitude = true;
                                            break;
                                        }
                                    case ("2"):
                                        {
                                            filteredMonsters = monsters.Where(m => m.Attitude == Monster.EmotionalState.sad).ToList();
                                            filteredMonsters = filteredMonsters.OrderBy(m => m.Name).ToList();
                                            validAttitude = true;
                                            break;
                                        }

                                    case ("3"):
                                        {
                                            filteredMonsters = monsters.Where(m => m.Attitude == Monster.EmotionalState.angry).ToList();
                                            filteredMonsters = filteredMonsters.OrderBy(m => m.Name).ToList();
                                            validAttitude = true;
                                            break;
                                        }

                                    case ("4"):
                                        {
                                            filteredMonsters = monsters.Where(m => m.Attitude == Monster.EmotionalState.bored).ToList();
                                            filteredMonsters = filteredMonsters.OrderBy(m => m.Name).ToList();
                                            validAttitude = true;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("\tPlease enter a valid number.");
                                            break;
                                        }

                                }

                            } while (!validAttitude);
                            break;
                        }
                    case ("c"):
                        {
                            bool validActivity = false;
                            Console.WriteLine("\tFilter by active or inactive monsters?");
                            Console.WriteLine("\t1) Active");
                            Console.WriteLine("\t2) Inactive");
                            do
                            {
                                Console.Write("\t");
                                string userActivity = Console.ReadLine();
                                switch (userActivity)
                                {
                                    case ("1"):
                                        {
                                            filteredMonsters = monsters.Where(m => m.Active == true).ToList();
                                            filteredMonsters = filteredMonsters.OrderBy(m => m.Name).ToList();
                                            validActivity = true;
                                            break;
                                        }
                                    case ("2"):
                                        {
                                            filteredMonsters = monsters.Where(m => m.Active == false).ToList();
                                            filteredMonsters = filteredMonsters.OrderBy(m => m.Name).ToList();
                                            validActivity = true;
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("\tPlease enter either 1-2.");
                                        break;
                                }

                            } while (!validActivity);
                            break;
                        }
                    default:
                        Console.WriteLine("\tPlease enter a letter a-c");
                        validResponse = false;
                        break;
                }

            } while (!validResponse);
            //
            // display new list
            //
            Console.WriteLine("\t***************************");
            foreach (Monster monster in filteredMonsters)
            {
                MonsterInfo(monster);
                Console.WriteLine();
                Console.WriteLine("\t***************************");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// SCREEN: list all monsters
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayAllMonsters(List<Monster> monsters)
        {
            DisplayScreenHeader("All Monsters");

            //Console.WriteLine("\t***************************");
            //foreach (Monster monster in monsters)
            //{
            //    MonsterInfo(monster);
            //    Console.WriteLine();
            //    Console.WriteLine("\t***************************");
            //}

            foreach (Monster monster in monsters)
            {
                Console.Write(String.Format("0,-5"), $"{monster.Name}");
                Console.Write($"{-5} {monster.Age}");
                Console.Write($"{-5} {monster.Attitude}");
                Console.Write($"{-5} {monster.Tribe}");
                Console.Write($"{-5} {monster.Active}");
                Console.Write($"{-5} {monster.BirthDate:MM/dd}");
                Console.WriteLine();
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// SCREEN: monster detail
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayViewMonsterDetail(List<Monster> monsters)
        {
            DisplayScreenHeader("Monster Detail");

            //
            // display all monster names
            //
            Console.WriteLine("\tMonster Names");
            Console.WriteLine("\t-------------");
            foreach (Monster monster in monsters)
            {
                Console.WriteLine("\t" + monster.Name);
            }

            //
            // get user monster choice
            //
            Console.WriteLine();
            Console.Write("\tEnter name:");
            string monsterName = Console.ReadLine();

            //
            // get monster object
            //
            Monster selectedMonster = null;
            foreach (Monster monster in monsters)
            {
                if (monster.Name == monsterName)
                {
                    selectedMonster = monster;
                    break;
                }
            }

            //
            // display monster detail
            //
            Console.WriteLine();
            Console.WriteLine("\t*********************");
            MonsterInfo(selectedMonster);
            Console.WriteLine("\t*********************");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// SCREEN: add a monster
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayAddMonster(List<Monster> monsters)
        {
            Monster newMonster = new Monster();
            bool validAge;
            bool validAttitude;
            bool validTribe;
            bool validBirthDate;

            DisplayScreenHeader("Add Monster");

            //
            // add monster object property values
            //
            Console.Write("\tName: ");
            newMonster.Name = Console.ReadLine();

            do
            {
                Console.Write("\tAge: ");
                validAge = int.TryParse(Console.ReadLine(), out int age);


                if (!validAge)
                {
                    Console.WriteLine("\tPlease enter a valid age as a number.");
                }
                if (age < 0)
                {
                    Console.WriteLine("\tPlease enter a number greater than 0.");
                    validAge = false;
                }
                newMonster.Age = age;
            } while (!validAge);


            do
            {
                Console.Write("\tAttitude: ");
                string userResponse = Console.ReadLine();
                validAttitude = Enum.TryParse(userResponse, out Monster.EmotionalState attitude);
                bool inputNumber = Int32.TryParse(userResponse, out int attitudeNumber);

                if (!validAttitude)
                    {
                    Console.WriteLine($"\tPlease enter a valid attitude, such as {Monster.EmotionalState.angry} or {Monster.EmotionalState.sad}.");
                    }

                else if (inputNumber)
                {
                    Console.WriteLine($"\tPlease do not enter a number for the attitude");
                    validAttitude = false;
                }
                newMonster.Attitude = attitude;
            } while (!validAttitude);

            do
            {
                Console.Write("\tTribe: ");
                string userResponse = Console.ReadLine();
                validTribe = Enum.TryParse(userResponse, out Monster.TribeState tribe);
                bool inputNumber = Int32.TryParse(userResponse, out int attitudeTribe);

                if (!validTribe)
                {
                    Console.WriteLine($"\tPlease enter a valid tribe, such as {Monster.TribeState.underground} or {Monster.TribeState.desert}.");
                }

                else if (inputNumber)
                {
                    Console.WriteLine($"\tPlease do not enter a number for the tribe.");
                    validAttitude = false;
                }
                newMonster.Tribe = tribe;
            } while (!validTribe);

            do
            {
                Console.WriteLine("\tUse the format of 'Month/Day', with both being numbers.");
                Console.Write("\tMonth and Day of Birth: ");
                string userResponse = "2000/" + Console.ReadLine();
                validBirthDate = DateTime.TryParse(userResponse, out DateTime birthDate);

                if (!validBirthDate)
                {
                    Console.WriteLine("Please enter a valid birth date.");
                }
                else
                {
                    newMonster.BirthDate = birthDate;
                }
            } while (!validBirthDate);

            newMonster.Active = true;

            //
            // echo new monster properties
            //
            Console.WriteLine();
            Console.WriteLine("\tNew Monster's Properties");
            Console.WriteLine("\t-------------");
            MonsterInfo(newMonster);
            Console.WriteLine();
            Console.WriteLine("\t-------------");

            DisplayContinuePrompt();

            monsters.Add(newMonster);
        }

        /// <summary>
        /// SCREEN: delete monster
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayDeleteMonster(List<Monster> monsters)
        {
            DisplayScreenHeader("Deactivate Monster");
            bool validMonster = false;

            //
            // display all monster names
            //
            Console.WriteLine("\tMonster Names");
            Console.WriteLine("\t-------------");
            foreach (Monster monster in monsters)
            {
                if (monster.Active == true)
                {
                    Console.WriteLine("\t" + monster.Name);
                }
            }

            //
            // get user monster choice
            //
            do
            {
                Console.WriteLine();
                Console.Write("\tEnter name:");
                string monsterName = Console.ReadLine();

                //
                // get monster object
                //
                Monster selectedMonster = null;
                foreach (Monster monster in monsters)
                {
                    if (monster.Name == monsterName)
                    {
                        selectedMonster = monster;
                        break;
                    }
                }

                //
                // delete monster
                //
                if (selectedMonster != null)
                {
                    selectedMonster.Active = false;
                    Console.WriteLine();
                    Console.WriteLine($"\t{selectedMonster.Name} marked as inactive");
                    validMonster = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"\t{monsterName} not found");
                }
            } while (!validMonster);

            DisplayContinuePrompt();
        }

        /// <summary>
        /// SCREEN: update monster
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        /// 
        static void DisplayUpdateMonster(List<Monster> monsters)
        {
            bool validResponse = false;
            Monster selectedMonster = null;
            bool validAge;
            bool validEmotion;
            bool validTribe;
            bool validActivity;
            bool validDateTime;

            do
            {
                DisplayScreenHeader("Update Monster");

                //
                // display all monster names
                //
                Console.WriteLine("\tMonster Names");
                Console.WriteLine("\t-------------");
                foreach (Monster monster in monsters)
                {
                    Console.WriteLine("\t" + monster.Name);
                }

                //
                // get user monster choice
                //
                Console.WriteLine();
                Console.Write("\tEnter name:");
                string monsterName = Console.ReadLine();

                //
                // get monster object
                //

                foreach (Monster monster in monsters)
                {
                    if (monster.Name == monsterName)
                    {
                        selectedMonster = monster;
                        validResponse = true;
                        break;
                    }
                }

                //
                // feedback for wrong name choice
                //
                if (!validResponse)
                {
                    Console.WriteLine("\tPlease select a correct name.");
                    DisplayContinuePrompt();
                }

                //
                // update monster
                //

            } while (!validResponse);


            //
            // update monster properties
            //
            string userResponse;
            Console.WriteLine();
            Console.WriteLine("\tReady to update. Press Enter to keep the current info.");
            Console.WriteLine();
            Console.Write($"\tCurrent Name: {selectedMonster.Name} New Name: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                selectedMonster.Name = userResponse;
            }

            Console.Write($"\tCurrent Age: {selectedMonster.Age} New Age: ");
            do
            {
                userResponse = Console.ReadLine();
                if (userResponse != "")
                {
                    validAge = int.TryParse(userResponse, out int age);
                    selectedMonster.Age = age;
                    if (age < 0)
                    {
                        Console.WriteLine("\tPlease enter a number greater than 0.");
                        validAge = false;
                    }
                    else if (!validAge)
                    {
                        Console.WriteLine("\tPlease enter a valid age as a number.");
                    }
                }
                else
                {
                    validAge = true;
                }

            } while (!validAge);

            Console.Write($"\tCurrent Attitude: {selectedMonster.Attitude} New Attitude: ");
            do
            {
                userResponse = Console.ReadLine();
                if (userResponse != "")
                {
                    validEmotion = Enum.TryParse(userResponse, out Monster.EmotionalState attitude);
                    bool inputNumber = Int32.TryParse(userResponse, out int attitudeNumber);
                    if (!validEmotion)
                    {
                        Console.WriteLine($"\tPlease enter a valid attitude.");
                    }
                    else if (inputNumber)
                    {
                        Console.WriteLine($"\tPlease do not enter a number for the attitude");
                        validEmotion = false;
                    }
                    else
                    {
                        selectedMonster.Attitude = attitude;
                    }
                }
                else
                {
                    validEmotion = true;
                }
            } while (!validEmotion);

            Console.Write($"\tCurrent Tribe: {selectedMonster.Tribe} New Tribe: ");
            do
            {
                Console.Write("\t");
                userResponse = Console.ReadLine();

                if (userResponse != "")
                {
                    validTribe = Enum.TryParse(userResponse, out Monster.TribeState tribe);
                    bool inputNumber = Int32.TryParse(userResponse, out int attitudeTribe);

                    if (!validTribe)
                    {
                        Console.WriteLine($"\tPlease enter a valid tribe, such as {Monster.TribeState.underground} or {Monster.TribeState.desert}.");
                    }

                    else if (inputNumber)
                    {
                        Console.WriteLine($"\tPlease do not enter a number for the tribe.");
                        validTribe = false;
                    }
                    else
                    {
                        selectedMonster.Tribe = tribe;
                    }
                }
                else
                {
                    validTribe = true;
                }

            } while (!validTribe);

            Console.Write($"\tCurrent Birth Date {selectedMonster.BirthDate.Month}/{selectedMonster.BirthDate.Day} New BirthDate:");
            Console.WriteLine("\tUse the format of 'Month/Day', with both being numbers.");
            do
            {
                Console.Write("\t");
                userResponse = Console.ReadLine();
                if (userResponse != "")
                {
                    userResponse = "2000/" + userResponse;
                    validDateTime = DateTime.TryParse(userResponse, out DateTime birthDate);

                    if (!validDateTime)
                    {
                        Console.WriteLine("\tPlease enter a valid birth date.");
                    }
                    else
                    {
                        selectedMonster.BirthDate = birthDate;
                    }
                }
                else
                {
                    validDateTime = true;
                }

            } while (!validDateTime);

            Console.WriteLine("\tInput either 'true' or 'false'.");
            if (selectedMonster.Active == true)
            {
                Console.Write("\tMonster is currently active. ");
            }
            else
            {
                Console.Write("\tMonster is not currently active. ");
            }
            Console.Write("New Activity: ");
            do
            {
                userResponse = Console.ReadLine().ToLower();
                if (userResponse == "true")
                {
                    selectedMonster.Active = true;
                    validActivity = true;
                }
                else if (userResponse == "false")
                {
                    selectedMonster.Active = false;
                    validActivity = true;
                }
                else if (userResponse == "")
                {
                    validActivity = true;
                }
                else
                {
                    Console.WriteLine("Please input either true or false.");
                    validActivity = false;
                    Console.Write("\t");
                }
            } while (!validActivity);


            //
            // echo updated monster properties
            //
            Console.WriteLine();
            Console.WriteLine("\tNew Monster's Properties");
            Console.WriteLine("\t-------------");
            MonsterInfo(selectedMonster);
            Console.WriteLine();
            Console.WriteLine("\t-------------");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// SCREEN: write list of monsters to data file
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayWriteToDataFile(List<Monster> monsters)
        {
            DisplayScreenHeader("Write to Data File");

            //
            // prompt the user to continue
            //
            Console.WriteLine("\tThe application is ready to write to the data file.");
            Console.Write("\tEnter 'y' to continue or 'n' to cancel.");
            if (Console.ReadLine().ToLower() == "y")
            {
                DisplayContinuePrompt();
                WriteToDataFile(monsters);
                //
                // TODO process I/O exceptions
                //

                Console.WriteLine();
                Console.WriteLine("\tList written to data the file.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\tList not written to the data file.");
            }

            DisplayContinuePrompt();
        }

        #endregion

        #region FILE I/O METHODS

        /// <summary>
        /// write monster list to data file
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void WriteToDataFile(List<Monster> monsters)
        {
            string[] monstersString = new string[monsters.Count];

            //
            // create array of monster strings
            //
            for (int index = 0; index < monsters.Count; index++)
            {
                string monsterString =
                    monsters[index].Name + "," +
                    monsters[index].Age + "," +
                    monsters[index].Attitude + "," +
                    monsters[index].Tribe + "," +
                    monsters[index].Active + "," +
                    monsters[index].BirthDate;

                monstersString[index] = monsterString;
            }

            File.WriteAllLines("Data\\Data.txt", monstersString);
        }

        /// <summary>
        /// read monsters from data file and return a list of monsters
        /// </summary>
        /// <returns>list of monsters</returns>        
        static List<Monster> ReadFromDataFile()
        {
            List<Monster> monsters = new List<Monster>();

            //
            // read all lines in the file
            //
            string[] monstersString = File.ReadAllLines("Data\\Data.txt");

            //
            // create monster objects and add to the list
            //
            foreach (string monsterString in monstersString)
            {
                //
                // get individual properties
                //
                string[] monsterProperties = monsterString.Split(',');

                //
                // create monster
                //
                Monster newMonster = new Monster();

                //
                // update monster property values
                //
                newMonster.Name = monsterProperties[0];

                int.TryParse(monsterProperties[1], out int age);
                newMonster.Age = age;

                Enum.TryParse(monsterProperties[2], out Monster.EmotionalState attitude);
                newMonster.Attitude = attitude;

                Enum.TryParse(monsterProperties[3], out Monster.TribeState tribe);
                newMonster.Tribe = tribe;

                bool.TryParse(monsterProperties[4], out bool active);
                newMonster.Active = active;

                DateTime.TryParse(monsterProperties[5], out DateTime birthDate);
                newMonster.BirthDate = birthDate;

                //
                // add new monster to list
                //
                monsters.Add(newMonster);
            }

            return monsters;
        }

        #endregion

        #region CONSOLE HELPER METHODS

        /// <summary>
        /// display all monster properties
        /// </summary>
        /// <param name="monster">monster object</param>
        static void MonsterInfo(Monster monster)
        {
            Console.WriteLine($"\tName: {monster.Name}");
            Console.WriteLine($"\tActive: {monster.Active}");
            Console.WriteLine($"\tAge: {monster.Age}");
            Console.WriteLine($"\tAttitude: {monster.Attitude}");
            Console.WriteLine("\t" + monster.Greeting());
            Console.WriteLine($"\tTribe: {monster.Tribe}");
            Console.WriteLine($"\tBirth Date: {monster.BirthDate:MM/dd}");
        }

        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThe Monster Tracker");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using the Monster Tracker!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.Write("\tPress any key to continue.");
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
