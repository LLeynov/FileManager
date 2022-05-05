# Filemanager
<!-- TOC -->

- [Filemanager](#filemanager)
    - [Зачем она нужна?](#%D0%B7%D0%B0%D1%87%D0%B5%D0%BC-%D0%BE%D0%BD%D0%B0-%D0%BD%D1%83%D0%B6%D0%BD%D0%B0)
    - [Свойства программы :](#%D1%81%D0%B2%D0%BE%D0%B9%D1%81%D1%82%D0%B2%D0%B0-%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D1%8B-)
    - [Необходимые условия для использования продукта :](#%D0%BD%D0%B5%D0%BE%D0%B1%D1%85%D0%BE%D0%B4%D0%B8%D0%BC%D1%8B%D0%B5-%D1%83%D1%81%D0%BB%D0%BE%D0%B2%D0%B8%D1%8F-%D0%B4%D0%BB%D1%8F-%D0%B8%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F-%D0%BF%D1%80%D0%BE%D0%B4%D1%83%D0%BA%D1%82%D0%B0-)
    - [Как установить программу?](#%D0%BA%D0%B0%D0%BA-%D1%83%D1%81%D1%82%D0%B0%D0%BD%D0%BE%D0%B2%D0%B8%D1%82%D1%8C-%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D1%83)
    - [Как запустить программу?](#%D0%BA%D0%B0%D0%BA-%D0%B7%D0%B0%D0%BF%D1%83%D1%81%D1%82%D0%B8%D1%82%D1%8C-%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D1%83)
    - [Доступные для использования команды :](#%D0%B4%D0%BE%D1%81%D1%82%D1%83%D0%BF%D0%BD%D1%8B%D0%B5-%D0%B4%D0%BB%D1%8F-%D0%B8%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F-%D0%BA%D0%BE%D0%BC%D0%B0%D0%BD%D0%B4%D1%8B-)

<!-- /TOC -->
## Зачем она нужна?
Программа является консольным файловым менеджером начального уровня, который
покрывает минимальный набор функционала по работе с файлами.


## Свойства программы  
1. Вывод всех доступных для использования команд,с инструкциями. 
2. Просмотр файловой структуры с постраничным,настраиваемым выводом элементов. 
3. Копирование файлов и каталогов.
4. Удаление файлов и каталогов. 
5. Получение информации о файлах и каталогах. 
6. Вроде не падает :(

## Необходимые условия для использования продукта 
* [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/ru/vs/)
* [Язык программирования С#](https://www.youtube.com/watch?v=TrpHt6XTqLo)

## Как установить программу?
* Необходимо скачать репозиторий с сайта [GitHub](https://github.com/LLeynov/Lesson_9_Homework_Completed).

## Как запустить программу?
* Открыть скачанный репозиторий и запустить файл : [*Lesson_9_Homework_Completed.sln*](https://github.com/LLeynov/Lesson_9_Homework_Completed/blob/master/Screenshots/SLN.PNG)
* Запустить проект,нажав сочетание клавиш [*Ctrl + F5*](https://github.com/LLeynov/Lesson_9_Homework_Completed/blob/master/Screenshots/start.PNG).
* Создайте папку на диске "С" с названием Dirs, в ней папку dir1 и в ней текстовый документ 1.txt для облегчения тестирования функционала, так же создайте в папке Dirs папку dir2 (**Данный пункт носит рекомендательный характер**).

## Доступные для использования команды  
* [allcommands](https://github.com/LLeynov/Lesson_9_Homework_Completed/blob/master/Screenshots/Allcommans.PNG) - позволяет увидеть в информационном окне все доступные для использования команды. 
* [cd](https://github.com/LLeynov/Lesson_9_Homework_Completed/blob/master/Screenshots/cd.jpg) - переходит в указанный пользователем каталог.
* [ls](https://github.com/LLeynov/Lesson_9_Homework_Completed/blob/master/Screenshots/ls.PNG) "расположение каталога" -p (число,всё без скобок) - отображает древо файлов и каталогов указанной страницы.
* [filecp](https://github.com/LLeynov/Lesson_9_Homework_Completed/blob/master/Screenshots/filecp.PNG) - копирует файл из одного места в другое.
* [dircp](https://github.com/LLeynov/Lesson_9_Homework_Completed/blob/master/Screenshots/dircp.PNG) - копирует содержимое каталога в указаный каталог.
* [dirinfo](https://github.com/LLeynov/Lesson_9_Homework_Completed/blob/master/Screenshots/dirinfo.PNG) - отображает информацию о каталоге. 
* [fileinfo](https://github.com/LLeynov/Lesson_9_Homework_Completed/blob/master/Screenshots/Fileinfo.PNG) - отображает информацию о файле. 
* [dirrm](https://github.com/LLeynov/Lesson_9_Homework_Completed/blob/master/Screenshots/dirrm.PNG) - **ВНИМАНИЕ!** Удаляет выбранный каталог со всем содержимым внутри!
* [filerm](https://github.com/LLeynov/Lesson_9_Homework_Completed/blob/master/Screenshots/filerm.PNG) - **ВНИМАНИЕ!** Удаляет выбранный файл со всем содержимым внутри!
