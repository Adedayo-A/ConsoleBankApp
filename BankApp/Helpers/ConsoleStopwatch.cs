using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Helpers
{
    public class ConsoleStopwatch
    {
        public static ConsoleKey FlashPrompt(string prompt, TimeSpan interval)
        {
            // Capture the cursor position and console colors
            var cursorTop = Console.CursorTop;
            var colorOne = Console.ForegroundColor;
            var colorTwo = Console.BackgroundColor;

            // Use a stopwatch to measure time interval
            var stopwach = Stopwatch.StartNew();
            var lastValue = TimeSpan.Zero;

            // Write the initial prompt
            Console.Write(prompt);

            while (!Console.KeyAvailable)
            {
                var currentValue = stopwach.Elapsed;

                // Only update text with new color if it's time to change the color
                if (currentValue - lastValue < interval) continue;

                // Capture the current value, swap the colors, and re-write our prompt
                lastValue = currentValue;
                Console.ForegroundColor = Console.ForegroundColor == colorOne
                    ? colorTwo : colorOne;
                Console.BackgroundColor = Console.BackgroundColor == colorOne
                    ? colorTwo : colorOne;
                Console.SetCursorPosition(0, cursorTop);
                Console.Write(prompt);
            }

            // Reset colors to where they were when this method was called
            Console.ForegroundColor = colorOne;
            Console.BackgroundColor = colorTwo;

            return Console.ReadKey(true).Key;
        }
    }
}
