   M S B A M L   `   `   `  ����M  IWorkwearAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WorkwearAccountingWorkwearAccounting  5   	   #    WorkwearAccounting.ModuleFour   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WorkwearAccounting     5   	     � Title$  
ModuleFour��5   	   $	��700��6   $
��1050��6)    � WindowState$ 	Maximized=�66   .��5	      � .+�5
   
   o� -   5        $��mainMenu��5
   9   $��25��6   $��Stretch=�6   $	��Top=�6I   $��3��6a   .@�5      m� -   5        $��DataBase��5      $��База данных��6'   .@�5      m� -   5        $��	dataBaseS��5      $H��BНастроить соединение с имеющейся БД��6,   5      m� 5      -   5        $��Reports��5      $��Отчеты��6&   .@�5      m� -   5        $��ExelExporterButton��5      $)��#Экспорт таблицы Excel��65   5      m� 5      -   5        $��About��5      $��О программе��6&   6>   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgNorm��5         
IsReadOnly .    AutoGenerateColumns .  $y�Visible=�6Q   $��10,115,10,45q�6f      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ��  �� Path$ EmplPosition.Name�  5      $ Название��6%    67   �� $ WorkwearDirectory.Name�  5      $ Дата прихода��6%    6;   �� $  WorkwearDirectory.Category�5      �� 5   
   -   5        	 ��Name$	 
btnRefresh��5      $��Обновить��6%   $
��Left=�68   $��
379,58,0,0q�6S   $	��Top=�6g   $��76��6   $��23��6�   �� 5   
   -	   5        $	 
btnSearchP��5      $��
Поиск��6%   $
��Left=�65   $��
320,58,0,0q�6P   $	��Top=�6d   $��54��6|   $��22��6�   �� 5   
   -
   5        
 ��Name$
 lblNameP��5      $��Должность:��6"   $
��Left=�67   $��	18,55,0,0q�6R   $	��Top=�6e   �� 5   
   -   5         ��Name$ cbEmplPosition��5      $
��Left=�6+   $��	95,58,0,0q�6F   $	��Top=�6Y   $	��220��6q    �� DisplayMemberPath$
 Name��6�   ��6}   �� 6�   �� 5   
   -   5        $	 btnOpenRevenue��5      $.��(Новый приходной ордер��6)   $
��Left=�6I   $��
877,70,0,0q�6d   $	��Top=�6x   $	��155��6�   $��34��6�   5!      5"      