﻿namespace _01.ReformatCode
{
    using System;

    public class ReformatCodeStart
    {
        
        private static readonly EventHolder EventHolder = new EventHolder();

        public static void Main()
        {
            while (ExecuteNextCommand())
            {
            }

            Console.WriteLine(Event.Output);
        }

        private static bool ExecuteNextCommand()
        {
            try
            {
                string command = Console.ReadLine();
                if (command[0] == 'A')
                {
                    AddEvent(command);
                    {
                        return true;
                    }
                }

                if (command[0] == 'D')
                {
                    DeleteEvents(command);
                    {
                        return true;
                    }
                }

                if (command[0] == 'L')
                {
                    ListEvents(command);
                    {
                        return true;
                    }
                }

                if (command[0] == 'E')
                {
                    return false;
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = GetDate(command, "ListEvents");
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);
            EventHolder.ListEvents(date, count);
        }

        private static void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);
            EventHolder.DeleteEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date; 
            string title; 
            string location;
            GetParameters(command, "AddEvent", out date, out title, out location);

            EventHolder.AddEvent(date, title, location);
        }

        private static void GetParameters(
            string commandForExecution,
            string commandType,
            out DateTime dateAndTime, 
            out string eventTitle, 
            out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');

            int lastPipeIndex = commandForExecution.LastIndexOf('|');
            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));

            return date;
        }
    }
}
