   M S B A M L   `   `   `  ����M  IWorkwearAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WorkwearAccountingWorkwearAccounting  5   	   !    WorkwearAccounting.ModulOne   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WorkwearAccounting     5   	     � Title$3  -Внесение норм выдачи СИЗ��5   	   $	��700��6*   $
��1050��67    � WindowState$ 	Maximized=�6D   .��5	      � .+�5
   
   o� -   5        $��mainMenu��5
   9   $��25��6   $��Stretch=�6   $	��Top=�6I   $��3��6a   .@�5      m� -   5        $��DataBase��5      $��База данных��6'   .@�5      m� -   5        $��	dataBaseS��5      $H��BНастроить соединение с имеющейся БД��6,   6Y   5      m� 5      -   5        $��Reports��5      $��Отчеты��6&   .@�5      m� -   5        $��ExelExporterButton��5      $)��#Экспорт таблицы Excel��65   5      m� 5      -   5        $��About��5      $��О программе��6&   6>   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgNorm��5         
IsReadOnly .    AutoGenerateColumns .  $y�Visible=�6Q   $��10,115,10,45q�6f      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Должность��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   ��  �� Path$ EmplPosition.Name�  5      $ Название��6%    67   �� $ WorkwearDirectory.Name�  5      $ Категория��6%    68   �� $  WorkwearDirectory.Category�  5      $ Описание��6%    67   �� $# WorkwearDirectory.Description�  5      $ Ед. изм.��6%    67   �� $ WorkwearDirectory.Unit�  5      $ Количество��6%    69   �� $ Amount�  5      $ Срок носки��6%    69   �� $" WorkwearDirectory.TimeOfWear�5        5!   
   -   5        $ dgEmplPosition��5!       .  .  $y�Hidden=�6Y   $��83,74,57,45q�6m    5"        5#      $ Название��6%    67   �� $
 Name�  5$      $ Цех��6%    62   �� $ Manufactory.Name�5&      �� 5(   
   -	   5        	 ��Name$	 btnAdd��5(      $��Добавить��6!   $
��Left=�64   $��	17,33,0,0q�6O   $	��Top=�6b   $��68��6z   $��36��6�   6�   �� 5)   
   -
   5        $	 btnEdit��5)      $��Редакт��6"   $
��Left=�63   $��	90,33,0,0q�6N   $	��Top=�6a   $��68��6y   $��36��6�   6�   �� 5*   
   -   5        $	 
btnRefresh��5*      $��Обновить��6%   $
��Left=�68   $��
372,83,0,0q�6S   $	��Top=�6g   $��76��6   $��22��6�   6�   �� 5+   
   -   5        $	 	btnDelete��5+      $��Удалить��6$   $
��Left=�66   $��
163,33,0,0q�6Q   $	��Top=�6e   $��68��6}   $��36��6�   6�   �� 5,   
   -   5        $	 	btnSearch��5,      $��
Поиск��6$   $
��Left=�64   $��
313,83,0,0q�6O   $	��Top=�6c   $��54��6{   $��22��6�   6�   �� 5-   
   -   5        
 ��Name$
 lblName��5-      $��Должность:��6!   $
��Left=�66   $��	11,80,0,0q�6Q   $	��Top=�6d   �� 5.   
   -   5         ��Name$ cbEmplPosition��5.      $
��Left=�6+   $��	88,83,0,0q�6F   $	��Top=�6Y   $	��220��6q    �� DisplayMemberPath$
 Name��6�   ��6}   �� 6�   54      55      