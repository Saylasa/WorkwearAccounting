   M S B A M L   `   `   `  ����M  IWorkwearAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WorkwearAccountingWorkwearAccounting  5   	   ,    &WorkwearAccounting.AddWorkwearToPerson   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WorkwearAccounting     5   	     � Title$  AddWorkwearToPerson��5   	   $��413.803��6%   $��780.224��66   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgRevenue��5
         
IsReadOnly .    AutoGenerateColumns .  $y�Visible=�6T   $��10,10,10,41q�6i      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ��  �� Path$ Id�6P     5      $ Название��6%   $	 300 6g    67   �� $ WorkwearDirectory.Name�6g     5      $ Описание��6%   $	 330 6n    67   �� $# WorkwearDirectory.Description�6n     5      $ Ед.��6%   $ 60 6b    62   �� $ WorkwearDirectory.Unit�6b   5      �� 5   
   -   5        	 ��Name$	 	btnSelect��5      $��
Выбор��6$   $
��Left=�64   $��23��6O   $��
11,350,0,0q�6[   $	��Top=�6o   $��79��6�   6�   �� 5   
   -   5        $	 	btnCancel��5      $��Отмена��6$   $
��Left=�65   $��23��6P   $��
95,350,0,0q�6\   $	��Top=�6p   $��79��6�   6�   5      5      