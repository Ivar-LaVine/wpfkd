   M S B A M L   `   `   `  ����K  GDentalCabinetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DentalCabinetWPF.PagesDentalCabinetWPF.Pages  5      *    $DentalCabinetWPF.Pages.TimeTablePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:DentalCabinetWPF.Pages     5        N� Title$  TimeTablePage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   $	��600��6)   �� 5      $
��Auto �6   �� 5      $��* �6   $	��300��6)   �� 5      $
��Auto �6   �� 5      $	��250 �6   $	��250��6+    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   �� 
����ح�$��0��6%   $��0��62   $��5��6B   �� 5   
   $��Doctors��6   $��2��6"   $��16(�66   $��0��6D   �� 5   
   $��
Time Table��6   $��2��6%   $��16(�69   $��2��6G   �� 5   
   -   5         ��Name$ DataStackPanel��5      $��1��6-   $��2��6:   $��0��6K   $��1��6[   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ AddDoctorButton��5      $	��Add��62   $��75��6@   $	��5,5q�6K   6X   �� 5      -   5        $ EditDoctorButton��5      $
��Edit��63   $��75��6B   $	��5,5q�6M   6Z   �� 5      -   5        $ DeleteDoctorButton��5      $��Delete��65   $��75��6F   $	��5,5q�6Q   6^   �� 5      -   5         ��Name$ SearchComboBox��5   4   $	��100��6   $	��5,5q�6'   .@�5       �� .��6#   	Surname6,   �� 5!      .��6#   Name6)   �� 5"      .��6#   
Patronymic6/   5#      �� 5$      -   5         ��Name$ SearchTextBox��5$   [   $	��100��6   $	��5,5q�6&   6[   5%      &   System.Windows.Controls.DataGrid  5&      -   5          Name$ DoctorsDataGrid��5&      $��2��60   $��0��6=   $��Stretch=�5'      	   AutoGenerateColumns	 .  
   
IsReadOnly
 .    CanUserResizeRows .  ��65   ��  � ContextMenu 5)      �� 5*      .@�5+      m� -   5        $��
Add doctor��5+   #   67   m� 5,      -	   5        $��Edit doctor��5,   #   68   m� 5-      -
   5        $��Delete doctor��5-   #   6:   5.         Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ Surname��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   ��  �� Path$ surname�6[     52      $
 Name��6)   $ 3* 6U    67   �� $
 name�6U     53      $ 
Patronymic��6)   $ 3* 6a    6=   �� $ 
patronymic�6a     54      $	 DOB��6)   $ 3* 6l    66   �� $	 dob� �� StringFormat$ 
dd-MM-yyyy��6l     55      $ Phone��6)   $ 3* 6W    68   �� $ phone�6W     56      $
 Mail��6)   $ 5* 6U    67   �� $
 mail�6U     57      $ Registation Date��6)   $ 3* 6~    6C   �� $ reg_date�$ 
dd-MM-yyyy��6~     58      $ Position��6)   $ 3* 6]    6;   �� $ position�6]   5:      5;      �� 5<   
   -   5        $ Data2StackPanel��5<      $��1��6.   $��2��6;   $��2��6L   $��2��6\   .+�5=      �� $ 
Horizontal=�6   .+�5>      �� -   5        $ AddTimeTableButton��5>      $	��Add��65   $��75��6C   $	��5,5q�6N   6[   �� 5?      -   5        $ EditTimeTableButton��5?      $
��Edit��66   $��75��6E   $	��5,5q�6P   6]   �� 5@      -   5        $ DeleteTimeTableButton��5@      $��Delete��68   $��75��6I   $	��5,5q�6T   6a   5A        5B      -   5        $ TimeTableDataGrid��5B      $��2��62   $��0��6?   $��Stretch=�5C      	 .  
 .  .  ��65   ��  5E      �� 5F      .@�5G      m� -   5        $	��Add��5G   #   60   m� 5H      -   5        $
��Edit��5H   #   61   m� 5I      -   5        $��Delete��5I   #   63   5J       5L        5M      $	 Day��6)   $ * 6S    66   �� $	 day�6S     5N      $ 
Begin Time��6)   $ * 6_    6=   �� $ beg_time�6_     5O      $ End Time��6)   $ * 6]    6;   �� $ end_time�6]   5Q      5R      �� 5S   
   -   5         ��Name$ DialogGridSplitter��5S      $��3��63   $��1��6C   $��2��6P   $��Center=�6a   $��3��6~   
�������$y�Hidden=�6�   �� 5T   
   -   5        $# Doctors_TimeTableGridSplitter��5T      $��1��6>   $��1��6N   $��2��6[   $��Center=�6l   $��3��6�   
�������$y�Visible=�6�    � 5U   
   -   5          �Name$ DialogFrame��5U      $��1��6%   $��2��62   $��4��6C   $y�Hidden=�6S   5V      5W      