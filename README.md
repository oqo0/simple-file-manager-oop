Здравствуйте, Андрей.  
Писал этот файловый менеджер на Linux. Не знаю как он поведёт себя с файловой системой Windows, но должно работать.
По этой же причине не получилось реализовать показ содержимого дисков.  
Пытался писать как можно лучше и следовать принципам SOLID, но пока ощущение, что получился какой-то монстр. Удачи... 

### Простой файловый менеджер с использованием ООП

<kbd> <img src="./img/img.png" /> </kbd>

#### Функции:
- Просмотр файловой структуры.
- Копирование файлов \ каталогов.
- Удаление файлов \ каталогов.
- Информация о размерах и атрибутах файлов.
- Вывод файлов папки.

#### Команды:
```cd [папка]``` - открыть папку.  
```ld``` - подняться в директорию выше.  
```kd``` - открыть корневую директорию.  
```create [folder / file] [путь]``` - создать файл / директорию.  
```delete [folder / file] [путь]``` - удалить файл / директорию.  
```copy [folder / file] [откуда] [куда]``` - копировать файл / директорию.  
```rename [folder / file] [путь] [новое имя]``` - переименовать файл или директорию.  
```search [запрос]``` - поиск по маске.  
```page [номер страницы]``` - открыть страницу с файлами.  
```attributes [путь] [атрибут]``` - изменение атрибутов файлов.  
```quit``` - закрыть программу.