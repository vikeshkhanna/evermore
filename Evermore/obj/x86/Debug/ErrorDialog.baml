   M S B A M L   `   `   `  ����  Evermore    Evermore.ErrorDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ErrorDialog��5   	   $
��Auto��6   $
��Auto��6+    � AllowsTransparency .  � ShowInTaskbar .   � WindowStyle$
 None=�5       � WindowStartupLocation$ CenterScreen=�62    � 
ResizeMode$ NoResize=�6W    � Topmost . ��5      �� 5   
    �� Color$ Black��6    �� Opacity$	 0.7Q�6(   	 � Triggers	 5	      :� 5
   
   
 :� RoutedEvent$
 Window.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S    g� Duration$ 0:0:1D�6Z   5      5      5       � 	Resources 5       �� 
TargetType   MetroDialogButton �� BasedOn3  -System.Windows.Media.Effects.DropShadowEffect  ErrorDialogDropShadow   ShadowDepth   
BlurRadius   Opacity   Color �� Property �� Value��%  '��       7   &	 &     '�� s     �� 5   
   " ��6   8   5        5   
   $ 0Q�69   $ 10Q�6I   $	 0.6Q�5      $ Black��6)   �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$
 Wrap=�6-   5       5!      .��5#      � -   5         �Name$ 	OuterGrid��5#      
�������$
��Auto��61   $
��Auto��6>   $	��500��6L   $	��300��6[   ��5$   
   �� 5%      " �6   .�5&      ��  �@J�Effect 5'        5(      $ 0Q�6+   $ 20Q�6;   $	 0.6Q�6K   $ Black��6Y   5*      5+       � RowDefinitions 5.   
   �� 5/      $��20 �6   �� 50      $
��Auto �6   �� 51      $��30 �6   �� 52      $
��Auto �6   �� 53      $��20 �6   �� 54      $
��Auto �6   �� 55      $��20 �6    � ColumnDefinitions 57   
   �� 58      $��20 �6   �� 59      $��* �6   �� 5:      $��20 �6   .+�5<   
   �� $��1��6   $��1��6   .��5=      �� -   5         ��Name$ ErrorMessage��5=      $
��Wrap=�6.   
Testing!6L   6X   � 5>   
   $��3��6   $��1��6    5?      �� 5@      $
��Auto �6#   �� 5A      $��20 �6#   �� 5B      $
��Auto �6#   �� 5C      $��* �6#   .+�5E      �� -   5         �� 	IsDefault .  �� IsCancel . .��5E   K   OK6O   �� 5F      -   5         ��Name$ MoreInfoButton��5F      $��0��6-   $��2��6:   .��6g   Dafuq?6o   5G      �� 5H   
   $��5��6   $��1��6   
���  ��.��5I      �� -   5        $ MoreInfoLabel��5I      $y�	Collapsed=�6/   $w��qMore Info. has not been implemented. We expect you to know how to read stack traces and compile the linux kernel.��6F   5J      5K      5L      5M      