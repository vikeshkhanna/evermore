   M S B A M L   `   `   `  ����  Evermore    Evermore.ToastWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  Toast��5   ?    � Title$ ToastWindow��5   	   $
��Auto��6   $	��200��6+   $	��300��6;    � WindowStyle$
 None=�6G    � 
ResizeMode$ NoResize=�6Z    � Topmost .  � AllowsTransparency .  � ShowInTaskbar .   � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5	      �� .��5
      �� .��5      W� 	 �� TargetProperty$	 Opacity�6&   
 W� From$
 0X�6J   	 W� To$ 1X�6S    g� Duration 6Z   ��  �� Path$ AnimationTime�5      5      5      ��5      �� 5   
    �� 
TargetType" �6    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5      ��  �� Property �@�Cursor �� Value$
 Hand��66   �� 5       � ��$ 20q�60   5      5      .��5      � ��5   
   �� 5      " �6   .�5      ��  �@J�Effect   DropShadowEffect# [  6+   5       ��5"   
   �� 5#       �� 
StartPoint$ 0.5,0&�6"    �� EndPoint$ 0.5,1&�65   .��5$      �  � Color$ #999999��6    � Offset$ 0Q�6/   � 5%      $ Black��6   $	 1.9Q�6-   5&       � RowDefinitions 5(   
   �� 5)      $
��Auto �6   �� 5*      $��* �6    � ColumnDefinitions 5,   
   �� 5-      $
��Auto �6   �� 5.      $��5 �6   �� 5/      $��* �6   .+�51   
   � $��0��6   $��0��6   
���  ��$��3��6A   ��52      �� 53      " �6   .�54      ��  �@J�Effect# [  6/   55       57      �� 58      $
��Auto �6     5:      �� 5;      $
��Auto �6#   �� 5<      $��* �6#   �� 5=      $
��Auto �6#   �� 5>      $��10 �6#   .+�5@      �� $��0��6   $��0��6!   
�������.��6E   Evermore Notification6\   5A      �� 5B   
   $��1��6   $��0��6   $*��$/Evermore;component/Images/toast.jpg��6-   $��64��6[   $��64��6g   $��Center=�5C      $��10q�6+   �� 5D      $��1��6   $��2��6!   $��Center=�61   .��5E      �� -   5         ��Name$ ToastMessage��5E      $
��Wrap=�62   
�������5F      5G      5H      5I      