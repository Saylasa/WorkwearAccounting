   M S B A M L   `   `   `  ����M  IWorkwearAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WorkwearAccountingWorkwearAccounting  5   	   $    WorkwearAccounting.ModuleThree   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WorkwearAccounting     5   	     � Title$  ModuleThree��5   	   $	��700��6   $
��1050��6*    � WindowState$ 	Maximized=�67   .��5	      � .+�5
   
   o� -   5        $��mainMenu��5
   9   $��25��6   $��Stretch=�6   $	��Top=�6I   $��3��6a   .@�5      m� -   5        $��DataBase��5      $��База данных��6'   .@�5      m� -   5        $��	dataBaseS��5      $H��BНастроить соединение с имеющейся БД��6,   5      m� 5      -   5        $��Reports��5      $��Отчеты��6&   .@�5      m� -   5        $��ExelExporterButton��5      $)��#Экспорт таблицы Excel��65   5      m� 5      -   5        $��About��5      $��О программе��6&   6>   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgPerson��5         
IsReadOnly .    AutoGenerateColumns .  $y�Visible=�6S   $��10,105,10,45q�6h      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   ��  �� Path$ Surname�  5      $ Имя��6%    62   �� $
 Name�  5      $ Отчество��6%    67   �� $ 
Patronymic�  5      $ Пол��6%    62   �� $	 Sex�  5      $ Цех��6%    62   �� $ Manufactory.Name�  5      $ Должность��6%    68   �� $ EmplPosition.Name�5        5   
   -   5        $ dgEmplPosition��5       .  .  $y�Hidden=�6Y   $��83,74,57,45q�6m    5         5!      $ Название��6%    67   �� $
 Name�  5"      $ Цех��6%    62   �� $ Manufactory.Name�5$      �� 5%   
   -	   5        	 ��Name$	 
btnRefresh��5%      $��Обновить��6%   $
��Left=�68   $��
376,40,0,0q�6S   $	��Top=�6g   $��76��6   $��49��6�   �� 5&   
   -
   5        $	 
btnSearchP��5&      $��
Поиск��6%   $
��Left=�65   $��
317,40,0,0q�6P   $	��Top=�6d   $��54��6|   $��22��6�   6�   �� 5'   
   -   5        
 ��Name$
 lblNameP��5'      $��Должность:��6"   $
��Left=�67   $��	15,37,0,0q�6R   $	��Top=�6e   �� 5(   
   -   5         ��Name$ cbEmplPosition��5(      $
��Left=�6+   $��	92,40,0,0q�6F   $	��Top=�6Y   $	��220��6q    �� DisplayMemberPath$
 Name��6�   ��6}   �� 6�   �� 5)   
   -   5        $	 
btnSearchN��5)      $��
Поиск��6%   $
��Left=�65   $��
317,67,0,0q�6P   $	��Top=�6d   $��54��6|   $��22��6�   6�   �� 5*   
   -   5        $
 lblName��5*      $��Фамилия:��6!   $
��Left=�64   $��	15,64,0,0q�6O   $	��Top=�6b   �� 5+   
   -   5        $ cbPerson��5+      $
��Left=�6%   $��	92,67,0,0q�6@   $	��Top=�6S   $	��220��6k   $
 Name��6�   ��6w   �� 6�   �� 5,   
   -   5        $	 btnOpenCard��5,      $��Карта учета��6&   $
��Left=�6<   $��
877,37,0,0q�6W   $	��Top=�6k   $	��155��6�   $��34��6�   6�   5/      50      