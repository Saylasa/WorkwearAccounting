   M S B A M L   `   `   `  ����M  IWorkwearAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WorkwearAccountingWorkwearAccounting  5   	   )    #WorkwearAccounting.AddRevenueWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WorkwearAccounting     5   	     � Title$  AddRevenueWindow��5   	   $��433.331��6#   $��640.425��64   .��5	      � .+�5
   
   �� $ ��Размер одежды:��6   $
��Left=�6)   $��
10,105,0,0q�6D   $	��Top=�6X   �� 5   
   -   5         ��Name$ 
cbWorkwear��5      $
��Left=�6'   $��169,107,0,0q�6B   $	��Top=�6W   $	��146��6o    �� DisplayMemberPath$
 Name��6�   ��6{   �� 6�   �� 5   
   -   5         ��Name$ btnSave��5      $��Сохранить��6"   $
��Left=�66   $��	5,364,0,0q�6Q   $	��Top=�6d   $��91��6|   $��29��6�   6�   �� 5   
   -   5        $ 	btnCancel��5      $��Отмена��6$   $
��Left=�65   $��101,364,0,0q�6P   $	��Top=�6e   $��86��6}   $��29��6�   �� 5   
   $��Дата прихода:��6   $
��Left=�6(   $��	10,10,0,0q�6C   $	��Top=�6V   �� 5   
   -   5         ��Name$ tbAmount_Copy��5      $
��Left=�6)   $��23��6D   $��
169,10,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��146��6�   �� 5   
   $��Размер обуви:��6   $
��Left=�6(   $��	10,78,0,0q�6C   $	��Top=�6V   �� 5   
   -   5        $ cbWorkwear_Copy��5      $
��Left=�6,   $��
169,80,0,0q�6G   $	��Top=�6[   $	��146��6s   $
 Name��6�   ��6   �� 6�   �� 5   
   $$��Размер перчаток:��6   $
��Left=�6+   $��
10,132,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5        $ cbWorkwear_Copy1��5      $
��Left=�6-   $��169,134,0,0q�6H   $	��Top=�6]   $	��146��6u   $
 Name��6�   ��6�   �� 6�   �� 5   
   $1��+Размер головного убора:��6   $
��Left=�62   $��
10,159,0,0q�6M   $	��Top=�6a   �� 5   
   -   5        $ cbWorkwear_Copy2��5      $
��Left=�6-   $��169,161,0,0q�6H   $	��Top=�6]   $	��146��6u   $
 Name��6�   ��6�   �� 6�   �� 5   
   -   5        $ btnSave_Copy��5      $;��5Добавить ед. СИЗ в справочник��6'   $
��Left=�6O   $��
411,10,0,0q�6j   $	��Top=�6~   $	��211��6�   $��29��6�   �� 5   
   $��Единица СИЗ:��6   $
��Left=�6'   $��	10,51,0,0q�6B   $	��Top=�6U   �� 5   
   -	   5        $ cbWorkwear_Copy3��5      $
��Left=�6-   $��
169,53,0,0q�6H   $	��Top=�6\   $	��146��6t   $
 Name��6�   ��6�   �� 6�   &   System.Windows.Controls.DataGrid  5   
   -
   5          Name$ dgEmplPosition��5         
IsReadOnly .    AutoGenerateColumns .  $y�Visible=�6Y   $��10,190,10,45q�6n   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Название��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   ��  �� Path$
 Name�  5      $
 Описание��6%    67   �� $ Manufactory.Name�  5      $
 Время носки��6%    6:   �� $ Manufactory.Name�  5       $
 Ед. изм.��6%    67   �� $ Manufactory.Name�  5!      $
 Описание��6%    67   �� $ Manufactory.Name�  5"      $%
 Дата поступления��6%    6?   �� $ Manufactory.Name�  5#      $
 Размер��6%    65   �� $ Manufactory.Name�5&      �� 5'   
   -   5        $ btnSave_Copy1��5'      $��Добавить��6(   $
��Left=�6;   $��509,147,0,0q�6V   $	��Top=�6k   $	��113��6�   $��36��6�   5(      5)      