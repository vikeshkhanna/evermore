   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      C ?Evermore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:EvermoreEvermore 5         Evermore.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6clr&clr-namespace:System;assembly=mscorlib     5      +evermoreclr-namespace:Evermore     5        �� 	Resources  5      &   Evermore.InverseBooleanConverter   BoolInverter#  Evermore.EmptyStringConverter  EmptyStringConverter �� 
TargetType �� Property �� Value  PageHeaderLabelStyle3  -System.Windows.Media.Effects.DropShadowEffect  DropShadowEffect   ShadowDepth   
BlurRadius   Opacity   Color  DropShadowMandatoryInput  DropShadowValidInput  StageOneFooter  TextBoxStyle �� Triggers	 P� Property
 P� Value  MetroCheckBoxStyle 	 CheckBoxFocusVisual �� 
TargetType �� 
Background �� Bullet ��Name �� CornerRadius �� Color �� 
StartPoint �� EndPoint � Color � Offset F�Name J� SnapsToDevicePixels'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName R� KeyTime R� Value  System.Windows.Visibility   Visible	 �� To  g� Duration 
 MetroButton! � 	Resources  Key" �� Padding# ��Name  ShadowStyle$ T� X% T� Y& �� Triggers' �� 
TargetName  MetroDialogButton( �� BasedOn��%e  &	        &	      '�� &     &	 �     &	     &	 N    &	 �    &	 �    &	     7  &	 V    7  &	
  
    7  &	 �    7 
   5   
   6+     5	   
   6(   �� 5   
   " ��6   .�5      ��  � ��$ Segoe)�6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6-   .�5      ��  � ��$ 32(�6)   5        5   
   $ 0Q�64   $ 10Q�6D   $	 0.6Q�6T   $ Black��6b     5   
   $ 0Q�6<   $ 5Q�6L   $
 0.75Q�6[   $	 Red��6j     5   
   $ 0Q�68   $ 10Q�6H   $	 0.9Q�6X   $ 
LightGreen��6f   ��5   
   Some information, first.��6G   �� 5   
    5      P� 5      	 �@J�	IsFocused
 . . �5      ��  �@J�Effect8   67   5      .�5!      ��  � ��$ 14(�61   �� 5"       � ��$
 Auto��6/   �� 5#       � ��$ Stretch=�6:   �� 5$       � ��$ Stretch=�6<   �� 5%       � ��$
 Auto��6.   5&      �� 5*   
   " ��6+   .�5+      ��  �@J�SnapsToDevicePixels . 64   �� 5,       �@�OverridesDefaultStyle . 66   �� 5-       �@�FocusVisualStyle# � 	 61   �� 5.       � ��$ 5,5,5,5q�6'   �� 5/       � �� 50      �� 51      " ��6&   .R�52      �� 
 ����  53      �� 54   "   $ MetroCheckBoxBorder��6)   $��25��6F   $��25��6Q   $ 0��55   )   $��3q�6:   ��56   &   �� 57   *   $ DarkRed��6:   ��59   &   �� 5:   *   $	 0,0&�6>   $	 0,1&�6O   ��5<   2   � � 5=   6   $ White��6C   � 5>   6   $ 	LightGray��6C   $	 4.0Q�6U   5?   3   5A   +   ._�5C   &   F� $ 	CheckMark��6W   $y�	Collapsed=�6+   $��7��6B   $��7��6L    .  $��2��5D   G   +����    @B �@B ��j �    ��j � z     	��5E   *   �� 5F   .   $ Black��6>   5H   '   5I   #    5K        5L   "   CommonStates��. 5M   &     
Normal��62     5N   &   	MouseOver��. 5O   *   �� .��5P   .   T� $ (Border.Effect)�6L   $ MetroCheckBoxBorder��5Q   2   ..�5R   2   i� $ 0��6I   8   6U   5S   /   5T   +   5U   '   5V   #     5W   "   CheckStates��. 5X   &     Checked��. 5Y   *   �� .��5Z   .   T� $ (UIElement.Visibility)�6L   $ 	CheckMark��5[   2   ..�5\   2   i� $ 0��6I   # Z 6U   5]   /   �� 5^   .   $ MetroCheckBoxBorder��6=   $" (Border.BorderBrush).(Color)�6i   $ GreenX�5_   =   $  00:00:01D�6H   5`   +   5a   '     5b   &   	Unchecked��62   5c   #   ._�5f      �� $��4,0,0,0q�6/   $��Center=�5g      $
��Left=�5h      ��. 5i      5j      5l      5n      �� 5o       � ��$ 14(�6)   �� 5p       � ��$ Segoe)�6+   5q      �� 5t   
   " ��6   .�5u      ��  � ��$ Segoe)�6+   �� 5v       � ��$ 24(�6)   �� 5w       � ��$
 Auto��6&   �� 5x       � ��$
 Auto��6'   �� 5y       � ��$ 100,10,10,10q�6(   �� 5z       � ��$ Center=�62   �� 5{       � ��
 ���� 6+   �� 5|       �@�OverridesDefaultStyle . 66   �� 5~       �@J�Effect 5        5�      $ 0Q�6'   $ 10Q�67   $ White��6G   5�      �� 5�       � �� 5�      �� 5�      " ��6&   ! 5�      ���� 5�      ShadowStyle .�5�   "   ��  � ��
 �   �6G   5�      5�      .R�5�      �� $ MetroButtonBorder��6!   $	" 2,2q�6<   $��1q�6J   
�������$ 0��5�   %   #��z��66   ._�5�      � .+�5�   "   �� $!# MetroButtonContentPresenter��63   $��Center=�6X   $��Center=�6u   $
��Auto��5�   7   $
��Auto��6D   $��	10,0,10,5q�6R   8��  z�5�   &   T� 5�   *   $	$ 1.0Q�6=   $	% 1.0Q�6E   5�   #   5�      5�      & 5�      P� 5�      	 � ��
 . . �5�   "   �� $' MetroButtonBorder��6*    � ��
 �����6_   5�      P� 5�      	 �@J�IsMouseOver
 . . �5�   "   ��  �@J�Effect 5�   &     5�   *   $ 0Q�6;   $ 10Q�6K   $ Tomato��6[   5�   #   �� 5�   "    �@�Cursor$
 Hand��6;   5�      P� 5�      	 � {�
 .  . �5�   "   ��  �@J�Opacity$	 0.2Q�6<   �� 5�   "    � ��
 �����6?   5�      5�      5�      5�      �� 5�   
   " ��6*   8(   .�5�      ��  �@J�Effect 5�        5�      $ 0Q�6'   $ 10Q�67   $	 0.6Q�6G   $ Black��6U   5�      �� 5�       � ��
 �����6+   �� 5�       � ��$ Center=�62   5�      5�      5�      