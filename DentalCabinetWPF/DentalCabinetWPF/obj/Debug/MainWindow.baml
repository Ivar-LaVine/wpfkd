   M S B A M L   `   `   `  ����K  GDentalCabinetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DentalCabinetWPFDentalCabinetWPF  5   	   !    DentalCabinetWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DentalCabinetWPF     5   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1400��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��150 �6   $	��150��6+   �� 5      $
��Auto �6   �� 5      $
��1200 �6   $	��250��6,    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� .+�5      �� -   5        $	��100��5      $��Doctors��6!   $
��10 5q�6O   �� 5      -   5        $	��100��5      $��Patients��6!   $
��10 5q�6Q   �� 5      -   5        $	��100��5      $��	Positions��6!   $
��10 5q�6S   �� 5      -   5        $	��100��5      $��Services��6!   $
��10 5q�6Q   �� 5      -   5        $	��100��5      $��Talons��6!   $
��10 5q�6M   �� 5      -   5        $	��100��5      $��
Time Table��6!   $
��10 5q�6T   �� 5      $	��100��6   $��Orders��6!   $
��10 5q�62   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   .+�5      �� -   5         ��Name$ PreviousPageButton��5   s   $��50��6   $��Previous��6    $��20��63   $��	10 0 10 0q�6?   6s   �� 5      -   5        $ NextPageButton��5   k   $��50��6   $
��Next��6    $��20��6/   $��	10 0 10 0q�6;   6k   5      �� 5    
   $ 
Horizontal=�6   $��1��6.   $��2��6;   $��Right=�6K   .+�5!      �� -	   5        $ ClosePageButton��5!   m   $��50��6   $��Close��6    $��20��60   $��	10 0 10 0q�6<   6m   5"      �� 5#   
   $��1��6   $��2��6'   $��3��68   $��Center=�6B   
���   �6_    � 5$   
   -
   5          �Name$ 	PageFrame��5$      $��2��6K     � NavigationUIVisibility$ Hidden=�6[   5%      5&      