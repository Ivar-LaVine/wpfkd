   M S B A M L   `   `   `  ����K  GDentalCabinetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DentalCabinetWPF.PagesDentalCabinetWPF.Pages  5      )    #DentalCabinetWPF.Pages.PatientsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:DentalCabinetWPF.Pages     5        N� Title$  PatientsPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   $	��250��6)   �� 5      $
��Auto �6   �� 5      $	��250 �6   $	��250��6+    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   �� 
����ح�$��0��6%   $��0��62   $��3��6B   �� 5   
   $��Patients��6   $��3��6#   $��16(�67   �� 5   
   -   5         ��Name$ DataStackPanel��5      $��1��6-   $��2��6:   $��0��6K   $��3��6[   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ AddPatientButton��5      $	��Add��63   $��75��6A   $	��5,5q�6L   6Y   �� 5      -   5        $ EditPatientButton��5      $
��Edit��64   $��75��6C   $	��5,5q�6N   6[   �� 5      -   5        $ DeletePatientButton��5      $��Delete��66   $��75��6G   $	��5,5q�6R   6_   �� 5      -   5         ��Name$ SearchComboBox��5   4   $	��100��6   $	��5,5q�6'   .@�5      �� .��6#   	Surname6,   �� 5      .��6#   Name6)   �� 5      .��6#   
Patronymic6/   5       �� 5!      -   5         ��Name$ SearchTextBox��5!   [   $	��100��6   $	��5,5q�6&   6[   5"      &   System.Windows.Controls.DataGrid  5#      -   5          Name$ PatientsDataGrid��5#      $��2��61   $��0��6>   $��Stretch=�5$      	   AutoGenerateColumns	 .  
   
IsReadOnly
 .    CanUserResizeRows .  ��65   ��  � ContextMenu 5&      �� 5'      .@�5(      m� -   5        $��Add patient��5(   #   68   m� 5)      -	   5        $��Edit patient��5)   #   69   m� 5*      -
   5        $��Delete patient��5*   #   6;   5+         Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Surname��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   ��  �� Path$ surname�6[     5/      $
 Name��6)   $ 3* 6U    67   �� $
 name�6U     50      $ 
Patronymic��6)   $ 3* 6a    6=   �� $ 
patronymic�6a     51      $	 DOB��6)   $ 3* 6l    66   �� $	 dob� �� StringFormat$ 
dd-MM-yyyy��6l     52      $ Snills��6)   $ 3* 6Y    69   �� $ snills�6Y     53      $	 OMS��6)   $ 3* 6S    66   �� $	 oms�6S     54      $ Passport��6)   $ 5* 6]    6;   �� $ passport�6]   56      57      �� 58   
   -   5         ��Name$ DialogGridSplitter��58      $��1��63   $��1��6C   $��2��6P   $��Center=�6a   $��3��6~   
�������$y�Hidden=�6�    � 59   
   -   5          �Name$ DialogFrame��59      $��1��6%   $��2��62   $��2��6C   $y�Hidden=�6S   5:      5;      