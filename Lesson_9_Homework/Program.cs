using System;
using System.IO;
using System.Text;
using Lesson_9_Homework.Properties;


namespace Lesson_9_Homework
{
    internal class Program
    {

        const int PAGE_SIZE_WIDTH/*ШИРИНА*/ = 160;//Задаём константу для ширины. 
        const int PAGE_SIZE_HEIGH/*ВЫСОТА*/ = 54;//Задаём константу для высоты.
        private static string currentDir = Settings.Default.saidomish;
        



        static void Main(string[] args)//Код,задающий параметры консоли. 
        {
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = "FileManager"; //Задаём название приложения. 
            Console.ForegroundColor = ConsoleColor.Green;//Задаём цвет шрифта. 
            Console.SetWindowSize(PAGE_SIZE_WIDTH, PAGE_SIZE_HEIGH);//Задаём размер консоли.  
            Console.SetBufferSize(PAGE_SIZE_WIDTH, PAGE_SIZE_HEIGH);

            DrawWindow(0, 0, PAGE_SIZE_WIDTH, 40);//Рисуем верхнее окно. 
            DrawWindow(0, 40, PAGE_SIZE_WIDTH, 10);//Рисуем среднее окно.
            
            UpdateConsole();
        }


        static void UpdateConsole()//Метод обновления консоли. 
        {
            DrawConsole(currentDir, 0, 50, PAGE_SIZE_WIDTH, 3);
            ProcessEnterCommand(PAGE_SIZE_WIDTH);          
        }

        static (int left, int top) GetCursorPosition()//Метод возвращения позиции курсора. 
        {
            return (Console.CursorLeft, Console.CursorTop);
        }




        static void ProcessEnterCommand(int width)//Не даёт пользователю зайти за границу нижней строки ввода,так же не даёт удалить путь. 
        {
            (int left, int top) = GetCursorPosition();
            StringBuilder command = new StringBuilder();
            char key;

            do
            {
                key = Console.ReadKey().KeyChar;

                if (key != 8 && key != 13)
                    command.Append(key);

                (int Left, int Top) = GetCursorPosition();

                if (Left == width - 2)
                {
                    Console.SetCursorPosition(left - 1, top);
                    Console.Write(" ");
                    Console.SetCursorPosition(Left - 1, top);
                }
                if (key == (char)8/*ConsoleKey.Backspace*/)
                {
                    if (command.Length > 0)
                        command.Remove(command.Length - 1, 1);

                    if (Left >= left)
                    {
                        Console.SetCursorPosition(Left, top);
                        Console.Write(" ");
                        Console.SetCursorPosition(Left, top);
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top);
                    }
                }
            }
            while (key != (char)13);
            ParseCommandString(command.ToString());
        }
        static void ParseCommandString(string command)
        {
            string[] commandParams = command.ToLower().Split(' ');
            if (commandParams.Length > 0)
            {
                try//Урок 6, работа с ловлей ошибок.
                { 
                switch (commandParams[0])
                {

                    case "allcommands"://Код отображает все доступные команды. 
                        Console.SetCursorPosition(0, 41);
                        Console.WriteLine("│Все доступные команды : \n│cd - переходит в указанный каталог │ ls - p n(где n является желаемой страницой) - отображает древо файлов и каталогов указанной страницы,\n│filecp - копирует файл из одного места в другое │ dircp - копирует содержимое каталога в указанный каталог, \n│dirinfo - отображает информацию о каталоге │ fileinfo - отображает информацию о файле,\n│dirrm - ВНИМАНИЕ! Удаляет выбранный каталог со всем содержимым внутри! │ filerm - ВНИМАНИЕ! Удаляе выбранный файл со всем содержимым!");
                        Console.WriteLine("│Что-нибудь жмякните,для продолжения. Обращаю ваше внимание,что верхние уровни консоли будут очищены.");
                        Console.ReadKey(true);
                        Console.Clear();
                        DrawWindow(0, 0, PAGE_SIZE_WIDTH, 40);
                        DrawWindow(0, 40, PAGE_SIZE_WIDTH, 10);

                        break;

                    case "cd": // Код,осуществляющий переходы по каталогам. 
                        if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                        {
                            currentDir = commandParams[1];
                        }
                        break;


                    case "ls": //Рисует дерево каталогов и файлов. 
                        if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                        {
                            if (commandParams.Length > 3 && commandParams[2] == "-p" && int.TryParse(commandParams[3], out int n))
                            {
                                DrawTree(new DirectoryInfo(commandParams[1]), n);
                            }
                            else
                            {
                                DrawTree(new DirectoryInfo(commandParams[1]), 1);
                            }
                        }
                        break;
                     

                    case "filecp": //Копирует файл из одного места в другое.
                        
                        Console.SetCursorPosition(0, 41);
                        Console.WriteLine("│Укажите полный путь копируемого файла!");
                        Console.WriteLine(@"│Пример : C:\Dirs\dir1\1.txt");
                        Console.SetCursorPosition(1, 43);
                        string path = Console.ReadLine();


                        Console.WriteLine("│Укажите путь нового расположения!");
                        Console.WriteLine(@"│Пример : C:\Dirs\dir2\1.txt");
                        Console.SetCursorPosition(1, 46);
                        string newPath = Console.ReadLine();
                        FileInfo fileInf = new FileInfo(path);
                        if (fileInf.Exists)
                        {
                            fileInf.CopyTo(newPath, true);
                        }
                        Console.SetCursorPosition(1, 47);
                        Console.WriteLine("Дело сделано!");
                        Console.WriteLine("│Что-нибудь жмякните,для продолжения.");
                        Console.ReadKey(true);
                        Console.SetCursorPosition(1, 46);

                        Console.Clear();
                        DrawWindow(0, 0, PAGE_SIZE_WIDTH, 40);
                        DrawWindow(0, 40, PAGE_SIZE_WIDTH, 10);
                        break;
                      


                    case "fileinfo": // Код отображающий пользователю информацию о файле. 

                        Console.SetCursorPosition(0, 41);
                        Console.WriteLine("│Укажите полный путь файла,для отображения информации о нём!");
                        Console.WriteLine(@"│Пример : C:\Dirs\dir1\1.txt");
                        Console.SetCursorPosition(1, 43);
                        string pathinfo = Console.ReadLine();
                        
                        FileInfo fileInfo = new FileInfo(pathinfo);
                        if (fileInfo.Exists)
                        {
                            Console.WriteLine($"│Имя файла: {fileInfo.Name}\n│Время создания: {fileInfo.CreationTime}\n│Размер: {fileInfo.Length} байт.");
                        
                            Console.SetCursorPosition(1, 47);
                            Console.WriteLine("Дело сделано!");
                            Console.WriteLine("│Что-нибудь жмякните,для продолжения. Обращаю ваше внимание,что верхние уровни консоли будут очищены.");
                            Console.ReadKey(true);
                        }
                        else
                            Console.WriteLine("│Допущена ошибка,возможно файл не существует или путь к нему указан некорректно ,попробуйте ещё раз.  :(");
                            Console.ReadKey(true);

                        Console.Clear();
                        DrawWindow(0, 0, PAGE_SIZE_WIDTH, 40);
                        DrawWindow(0, 40, PAGE_SIZE_WIDTH, 10);
                        break;

                    case "dirinfo": //Отображает пользователю информацию о каталоге. 

                        Console.SetCursorPosition(0, 41);
                        Console.WriteLine("│Укажите полный путь каталога,для отображения информации о нём!");
                        Console.WriteLine(@"│Пример : C:\Dirs\dir1");
                        Console.SetCursorPosition(1, 43);
                        
                        string dirName = Console.ReadLine();

                        DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                        if (dirInfo.Exists)
                        {
                            Console.WriteLine($"│Название каталога: {dirInfo.Name}\n│Полное название каталога: {dirInfo.FullName}\n│Время создания каталога: {dirInfo.CreationTime}\n│Корневой каталог: {dirInfo.Root}");

                            Console.WriteLine("│Что-нибудь жмякните,для продолжения. Обращаю ваше внимание,что верхние уровни консоли будут очищены.");
                            Console.ReadKey(true);
                            Console.SetCursorPosition(1, 46);
                        }
                        else
                        Console.WriteLine("│Допущена ошибка,возможно,что такой каталог не существует.  :(");
                        Console.ReadKey(true);

                        Console.Clear();
                        DrawWindow(0, 0, PAGE_SIZE_WIDTH, 40);
                        DrawWindow(0, 40, PAGE_SIZE_WIDTH, 10);
                        break;

                    case "dirrm": //ВНИМАНИЕ! Удаляет выбранный каталог со всем содержимым внутри. 

                        Console.SetCursorPosition(0, 41);
                        Console.WriteLine("│Укажите каталог,который хотите удалить! ВНИМАНИЕ! Будет удалено всё содержиоме каталога!");
                        Console.WriteLine(@"│Пример : C:\Dirs");
                        Console.SetCursorPosition(1, 43);
                        string dirName1 = Console.ReadLine();

                        DirectoryInfo dirInfo1 = new DirectoryInfo(dirName1);
                        if (dirInfo1.Exists)
                        {
                            dirInfo1.Delete(true);
                            Console.WriteLine("Каталог удален");
                        }
                        else
                        {
                            Console.WriteLine("│Каталог не существует,либо в названии допущена ошибка.\n│ВНИМАНИЕ! БУДЬТЕ ОСТОРОЖНЫ ПРИ ИСПОЛЬЗОВАНИИ ДАННОЙ КОМАНДЫ!");
                            Console.ReadKey(true);
                        }
                        Console.Clear();
                            DrawWindow(0, 0, PAGE_SIZE_WIDTH, 40);
                            DrawWindow(0, 40, PAGE_SIZE_WIDTH, 10);
                        break;

                    case "dircp"://Код копирует содержимое каталога в указанный каталог.

                        Console.SetCursorPosition(0, 41);
                        Console.WriteLine("│Укажите каталог,содержимое которого хотите скопировать!");
                        Console.WriteLine(@"│Пример : C:\Dirs");
                        Console.SetCursorPosition(1, 43);
                        string a = Console.ReadLine();
                        DirectoryInfo dirA = new DirectoryInfo(a);
                        if (dirA.Exists)
                        {
                            Console.WriteLine("│Укажите каталог, в который хотите поместить скопированное содержимое!");
                            Console.SetCursorPosition(1, 45);
                            string b = Console.ReadLine();
                            Rec_copy_dir(a, b);
                            Console.WriteLine("│Всё готово! Что-нибудь жмякните,для продолжения. Обращаю ваше внимание,что верхние уровни консоли будут очищены.");
                            Console.ReadKey(true);

                        }
                        else
                        Console.WriteLine("│Допущена ошибка,возможно,что такой каталог не существует.  :(");
                        Console.ReadKey(true);
                       
                        Console.Clear();
                        DrawWindow(0, 0, PAGE_SIZE_WIDTH, 40);
                        DrawWindow(0, 40, PAGE_SIZE_WIDTH, 10);
                        break;

                    case "filerm"://Код удаляет выбранный файл. 
                        
                        Console.SetCursorPosition(0, 41);
                        Console.WriteLine("│Укажите полный путь файла,для его удаления!");
                        Console.WriteLine(@"│Пример : C:\Dirs\dir1\1.txt");
                        Console.SetCursorPosition(1, 43);                       
                        string filepath = Console.ReadLine();
                        FileInfo filermInf = new FileInfo(filepath);
                        if (filermInf.Exists)
                        {
                            filermInf.Delete();
                            Console.WriteLine("│Всё готово! Что-нибудь жмякните,для продолжения. Обращаю ваше внимание,что верхние уровни консоли будут очищены.");
                            Console.ReadKey(true);
                        }
                        else
                        Console.WriteLine("│Допущена ошибка,возможно,что такой файл не существует.  :(");
                        Console.ReadKey(true);

                        Console.Clear();
                        DrawWindow(0, 0, PAGE_SIZE_WIDTH, 40);
                        DrawWindow(0, 40, PAGE_SIZE_WIDTH, 10);
                        break;
    
                }
                }
                catch
                {
                    Console.SetCursorPosition(0, 47);
                    Console.WriteLine("│Во время выполнения выбранных действий произошла ошибка,после прочтения информации нажмите пробел и консоль будет обновлена. ");
                    Console.WriteLine("│Введите : allcommands,для получения списка возможных команд,так же внутри каждой команды имеется инструкция.");
                    Console.ReadKey(true);
                    DrawWindow(0, 40, PAGE_SIZE_WIDTH, 10);
                }

            }
            UpdateConsole();
        }

        /// <summary>
        /// Рисуем дерево файлов. 
        /// </summary>
        /// <param name="dir">Параметро текущей дирректории</param>
        /// <param name="page">Параметр текущей страницы</param>
        static void DrawTree(DirectoryInfo dir, int page)
        {
            StringBuilder tree = new StringBuilder();
            GetTree(tree, dir, "", true);
            DrawWindow(0, 0, PAGE_SIZE_WIDTH, 1);
            (int left, int top) = GetCursorPosition();
            int pageLines = Settings.Default.Pagelines;//В конфигурационном файле должна быть настройка вывода количества  элементов на страницу.

            string[] lines = tree.ToString().Split(new char[] { '\n' });
            int pageTotal = (lines.Length + pageLines - 1) / pageLines;
            if (page > pageTotal)
                page = pageTotal;

            for(int i = (page -1) * pageLines, counter = 0; i < page * pageLines;i++, counter++)
            {
               if (lines.Length - 1 > i)
                {
                    Console.SetCursorPosition(left + 1, top + 1 + counter);
                    Console.WriteLine(lines[i]);
                }    
            }
            string footer = $"╡ {page} of {pageTotal} ╞";
            Console.SetCursorPosition(PAGE_SIZE_WIDTH / 2 - footer.Length / 2, 39);
            Console.WriteLine(footer);
        }

        



        static void GetTree(StringBuilder tree, DirectoryInfo dir, string indent, bool lastDirectory)
        {
            tree.Append(indent);
            if (lastDirectory)
            {
                tree.Append("└─");
                indent += "  ";
            }
            else
            {
                tree.Append("├─");
                indent += "│ ";
            }

            tree.Append($"{dir.Name}\n");

              


            FileInfo[] subFiles = dir.GetFiles();
            for (int i = 0; i < subFiles.Length; i++)
            {
                if (i == subFiles.Length - 1)
                {
                    tree.Append($"{indent}└─{subFiles[i].Name}\n");
                }
                else
                {
                    tree.Append($"{indent}├─{subFiles[i].Name}\n");
                }
            }

            DirectoryInfo[] subDirects = dir.GetDirectories();
            for (int i = 0; i < subDirects.Length; i++)
                GetTree(tree, subDirects[i], indent, i == subDirects.Length - 1);
        }

        /// <summary>
        /// Отрисовать консоль.
        /// </summary>
        /// /// <param name="dir">Текущая директория</param> 
        /// <param name="x">Начальная позиция по оси Х</param> 
        /// <param name="y">Начальная позиция по оси Y</param>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        
        static void DrawConsole(string dir, int x, int y, int width, int height)
        {
            DrawWindow(x, y, width, height);
            Console.SetCursorPosition(x + 1, y + height / 2);
            Console.Write($"{dir}>");
            Settings.Default.saidomish = $"{dir}";//Данные строчки позволяют сохранять состояние последнего активного каталога. 
            Settings.Default.Save();
        }


        /// <summary>
        /// Отрисовка окна.
        /// </summary>
        /// <param name="x">Начальная позиция по оси Х</param> 
        /// <param name="y">Начальная позиция по оси Y</param>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>

        static void DrawWindow(int x, int y, int width, int height)//Метод по отрисовке прямоугольника.
        {
            
            Console.SetCursorPosition(x, y);
            
            //Header - Шапка. 
            Console.Write("╔");
           
            for (int i = 0; i < width - 2; i++)
                Console.Write("▬");
            Console.Write("╗");

            
            
            //SideBars - Боковые панели. 
            Console.SetCursorPosition(x, y + 1);
            
            for (int i = 0; i < height - 2; i++)
            {
                Console.Write("│");
                for (int j = x + 1; j < x + width - 1; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("│");
            }

            //Footer - Шапка наоборот (нижняя шапка).
            Console.Write("╚");
            for (int i = 0; i < width - 2; i++)
            Console.Write("▬");
            Console.Write("╝");
        }




        static void Rec_copy_dir(string begin_dir, string end_dir)//Копирует всё содержимое каталога. 
        {
            //Берём нашу исходную папку
            DirectoryInfo dir_inf = new DirectoryInfo(begin_dir);
            //Перебираем все внутренние папки
            foreach (DirectoryInfo dir in dir_inf.GetDirectories())
            {
                //Проверяем - если директории не существует, то создаём;
                if (Directory.Exists(end_dir + "\\" + dir.Name) != true)
                {
                    Directory.CreateDirectory(end_dir + "\\" + dir.Name);
                }

                //Рекурсия (перебираем вложенные папки и делаем для них то-же самое).
                Rec_copy_dir(dir.FullName, end_dir + "\\" + dir.Name);
            }

            //Перебираем файлики в папке источнике.
            foreach (string file in Directory.GetFiles(begin_dir))
            {
                //Определяем (отделяем) имя файла с расширением - без пути (но с слешем "\").
                string filik = file.Substring(file.LastIndexOf('\\'), file.Length - file.LastIndexOf('\\'));
                //Копируем файлик с перезаписью из источника в приёмник.
                File.Copy(file, end_dir + "\\" + filik, true);
            }
        }
    }
} 
