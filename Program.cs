using System;
using System.Collections.Generic;

// Prints a chord name and asks for the corresponding chord notes.

namespace guessChordNotes
{
    class Program
    {

        static void Main(string[] args)
        {
            // Dictionary for the correct notes
            string[] A_key = { "A", "B", "C#", "D", "E", "F#", "G#" };
            string[] B_key = { "B", "C#", "D#", "E", "F#", "G#", "A#" };
            string[] C_key = { "C", "D", "E", "F", "G", "A", "B" };
            string[] D_key = { "D", "E", "F#", "G", "A", "B", "C#" };
            string[] E_key = { "E", "F#", "G#", "A", "B", "C#", "D#" };
            string[] F_key = { "F", "G", "A", "Bb", "C", "D", "E" };
            string[] G_key = { "G", "A", "B", "C", "D", "E", "F#" };


            // Starting variable
            string loop = "y";
            int count = 0;
            int count_correct = 0;
            string user_answer = "X";
            string answer = "Y";
            string answer_alt = "Y";
            bool my_check = true;
            bool alt = false;
            bool alt5 = false;
            string alt_third_fromkey = "-";
            string alt_fifth_fromkey = "-";
            List<string> pure_notes = new List<string>()
            {
                "A", "B", "C", "D", "E", "F", "G"
            };

            Random r = new Random();

            Console.WriteLine("Hi human. Input the chord you would like to know the notes of. \nYou can use both sharps (#) and flats (b). Have fun.");

            while (loop == "y")
            {
                bool first_answer_correct = true;

                List<string> my_chords = new List<string>()
                {      //add flats! and all other stuff
                    "Ab", "A", "A#", "Bb", "B", "C", "C#", "Db", "D", "D#", "Eb", "E", "F", "F#", "G", "G#"
                };

                //int index_chords = r.Next(0, my_chords.Count);
                int nature = r.Next(0, 2);
                //string chord = my_chords[index_chords];
                Console.Write("Input chord: ");
                string chord = Console.ReadLine();

                if (nature == 1)
                {
                    chord += "m";
                }
                Console.WriteLine($"This is the selected chord: {chord}.");

                // Count each prompt
                count += 1;

                //Generate the key with letters only
                char char_letter = chord[0];
                string first_letter = char_letter.ToString();
                int index = pure_notes.IndexOf(first_letter);
                List<string> second_part = pure_notes.GetRange(0, index);
                //FIX THE ´7:
                List<string> sorted_notes = pure_notes.GetRange(index, (7 - index));
                sorted_notes.AddRange(second_part);


                //Find the root 
                string root = char_letter.ToString();
                if (chord.Length > 1)
                    if (chord.Contains('#') || chord.Contains('b'))
                    {
                        char sharp_flat = chord[1];
                        string new_root = root.ToString() + sharp_flat.ToString();
                        root = new_root;
                    }


                //Find the correct letter (only) of the 3rd and 5th
                string third = sorted_notes[2];
                string fifth = sorted_notes[4];

                //Find the (sometimes wrong) 3rd and 5th from the "wrong" key
                // Find the key list 
                string dict_list = char_letter + "_key";
                var dictionary = new Dictionary<string, string[]>()
                    {
                        {"A_key", A_key},
                        {"B_key", B_key},
                        {"C_key", C_key},
                        {"D_key", D_key},
                        {"E_key", E_key},
                        {"F_key", F_key},
                        {"G_key", G_key},
                    };
                string[] correct_list = (dictionary[dict_list]);
                string third_fromkey = (correct_list[2]);
                string fifth_fromkey = (correct_list[4]);

                //For minor third 
                if (nature == 1)
                {
                    if (third_fromkey.Contains("#"))
                    {
                        third_fromkey = third_fromkey.Trim('#');
                    }
                    else
                    {
                        third_fromkey = third_fromkey + "b";
                    }
                }

                //Sharps 
                if (chord.Contains('#'))
                {
                    if (third_fromkey.Contains('b'))
                    {
                        third_fromkey = third_fromkey.Trim('b');
                        fifth_fromkey = fifth_fromkey + "#";
                    }
                    else
                    {
                        third_fromkey = third_fromkey + "#";
                        fifth_fromkey = fifth_fromkey + "#";
                        if (third_fromkey.Contains("##"))
                        {
                            alt_third_fromkey = (correct_list[3]);
                            alt = true;
                        }                        
                    }

                }
                if (third_fromkey.Contains("B#"))
                {
                    third_fromkey = "C";
                }
                if (third_fromkey.Contains("E#"))
                {
                    third_fromkey = "F";
                }
                if (fifth_fromkey.Contains("B#"))
                {
                    alt5 = true;
                    alt_fifth_fromkey = "C";
                }
                if (fifth_fromkey.Contains("E#"))
                {
                    alt5 = true;
                    alt_fifth_fromkey = "F";
                }

                //Flats WATCH OUT FOR B CHORD
                if (chord.Contains('b'))
                {
                    if (third_fromkey.Contains('#'))
                    {
                        third_fromkey = third_fromkey.Trim('#');
                    }
                    else
                        third_fromkey = third_fromkey + "b";

                    if (fifth_fromkey.Contains('#'))
                    {
                        fifth_fromkey = fifth_fromkey.Trim('#');
                    }
                    else
                        fifth_fromkey = fifth_fromkey + "b";


                }
                if (third_fromkey.Contains("Fb"))
                {
                    third_fromkey = "E";
                }
                if (third_fromkey.Contains("Cb"))
                {
                    third_fromkey = "B";
                }

                Console.WriteLine($"Root: {root} \nThird (key): {third_fromkey} \nFifth (key): {fifth_fromkey}");
                if (alt)
                {
                    Console.WriteLine($"Alternative third: {alt_third_fromkey}");
                }    
                if (alt5)
                {
                    Console.WriteLine($"Alternative fifth: {alt_fifth_fromkey}");
                }


            }

            // Find the alternative correct note list and alternative answer
            //string dict_list_alt = guitar_string + "_notes_alt";
            //var dictionary_alt = new Dictionary<string, string[]>()
            //    {
            //        {"E_notes_alt", E_notes_alt},
            //        {"A_notes_alt", A_notes_alt},
            //        {"D_notes_alt", D_notes_alt},
            //        {"G_notes_alt", G_notes_alt},
            //        {"B_notes_alt", B_notes_alt},
            //    };
            //string[] correct_list_alt = (dictionary_alt[dict_list_alt]);
            //string answer_alt = (correct_list_alt[fret]).ToUpper();


            //Console.WriteLine($"{guitar_string}{fret}");

            while (user_answer != answer && user_answer != answer_alt)
            {
                //Console.Write("Input a chord name. Possibilities: A, A#, B, C, C#, D, D#, E, F, F#, G, G#. Input: ");
                //string chord_letter = Console.ReadLine().ToUpper();

                //
                //Console.Write("[M]ajor or [m]inor: ");
                //string key = Console.ReadLine().ToUpper();
                //
                //Console.Write("Root: ");
                //user_answer = Console.ReadLine().ToUpper();
                //


                //Check if input valid

                string check = "#B";
                string check2 = "ABCDEFG";
                if (user_answer.Length > 1)
                {
                    my_check = check.Contains(user_answer[1]);
                }

                while (!check2.Contains(user_answer[0]) || user_answer.Length > 2 || my_check == false)
                {
                    Console.Write("Input a valid note: ");
                    user_answer = Console.ReadLine().ToUpper();
                    if (user_answer.Length > 1)
                    {
                        my_check = check.Contains(user_answer[1]);
                    }
                    else
                    {
                        my_check = true;
                    }
                }


                //      if (user_answer != answer && user_answer != answer_alt)
                //      {
                //          Console.WriteLine("Wrong. Try again!");
                //          first_answer_correct = false;
                //      }
                //      else
                //      {
                //          Console.WriteLine("Correct!");
                //          if (first_answer_correct)
                //          {
                //              count_correct += 1;
                //          }
                //      }
                //      Console.WriteLine($"User answer is {user_answer}, answer is {answer} (or {answer_alt})");
                //  }
                //  Console.Write("Continue? y/n: ");
                //  loop = Console.ReadLine();
                //
                //  while (loop != "y" && loop != "n")
                //  {
                //      Console.Write("Continue? y/n: ");
                //      loop = Console.ReadLine();
                //  }
                //
                //Console.WriteLine($"Your score is {count_correct}/{count}.");

            }
        }
    }
}




//# Asks for a chord name and outputs the corresponding chord notes.

//Notes = ["A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"]
//pure_notes = ["A", "B", "C", "D", "E", "F", "G"]

//# Starting variable
//loop = 'Y'

//while loop == 'Y':

//    # Determines which letter it needs to be  
//    sorted_notes = (pure_notes[index:]) + (pure_notes[:index])


//    root = chord_letter
//    third = sorted_notes[2]
//    fifth = sorted_notes[4]

//    # Determines the major or minor third but with wrong letters sometimes     
//indexN = Notes.index(chord_letter)
//    sorted_notesN = (Notes[indexN:]) + (Notes[:indexN])

//    # Find index of letter in list
//    index_sortedNotesN_rd = sorted_notesN.index(third)
//    index_sortedNotesN_th = sorted_notesN.index(fifth)


//    major_third = sorted_notesN[4]
//    minor_third = sorted_notesN[3]
//    alt_fifth = sorted_notesN[7]

//    if index_sortedNotesN_th != 7:
//        fifth = fifth + "#"

//    if key == 'M':
//        if index_sortedNotesN_rd == 4:
//            proper_third = third
//        elif index_sortedNotesN_rd == 3:
//            proper_third = third + "#"
//        else: # index_sortedNotesN_rd == 2
//            proper_third = third + "##"
//        print(f"\nThe notes of {chord_letter} are: {root}, {proper_third}, {fifth}")
//    else:
//        if index_sortedNotesN_rd == 3: 
//            proper_third = third
//        elif index_sortedNotesN_rd == 4:
//            proper_third = third + "b"
//        else: 
//            proper_third = third + "#"
//        print(f"\nThe notes of {chord_letter}m are {root}, {proper_third}, {fifth}")



//    if key == 'M':
//        if proper_third not in Notes or fifth not in Notes:
//            print(f"(or {root}, {major_third}, {alt_fifth})")
//    else: 
//        if proper_third not in Notes or fifth not in Notes:
//            print(f"(or {root}, {minor_third}, {alt_fifth})")

//    loop = input("New chord? Y/N: ").upper()

//print("\nByebye!")