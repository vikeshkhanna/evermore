   M S B A M L   `   `   `  ����  Evermore    Evermore.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   >   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6{   -   5          �Name$  EvermoreWindow��5   	    � Title$ Evermore��5   	   
�������$
��Auto��5   	   $	��525��6    � 	Resources 5      ��%    5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   �� 5      $��10 �6   6*   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5         ��Name$ 
PageCanvas��5      $��1��6)   $��Center=�66   6S   �� 5   
   -   5         ��Name$ 
labelError��5      $��2��6$   
�������$y�Visible=�6D   $��10,5,5,5q�6Y   .��5      �� -   5         ��Name$ SettingsLink��5      .�6I   
Settings6S   5      � 5   
   -   5         �Name$ ControlPanel��5      $��4��6   $��Bottom=�62   $��80��6J   ��5      �� 5      -   5        ControlPanelBrush�� �� Color$ 
BlueViolet��5   =   6R   	 � ColumnDefinitions	 5       �� 5!      $��* �6#   6/   �� 5"      $
��Auto �6#   62   �� 5#      $��10 �6#   60   �� 5$      $
��Auto �6#   62   �� 5%      $��20 �6#   60   ��5'      �� 5(      
 �� 
TargetType"
 �6   .�5)      ��  �� Property �@J�Effect �� Value 5*      3  -System.Windows.Media.Effects.DropShadowEffect  5+         ShadowDepth$ 0Q�6/      
BlurRadius$ 10Q�6?      Opacity$	 0.5Q�6O      Color$ Black��6]   5-      5.      .+�50      �� $��0��6   $��10,10,10,10q�6$   $��24(�6:   
�������$
��Left=�6[   $��Center=�6v   ��6�   ��  �� Path$ ControlPanelFooter�51      �� 55      -   5         ��Name$ buttonPrevious��55      $��1��6-      MetroButton#��[  6=   
�������$��<��6u   {�56   3   �� *CanMoveBack+�� 57      -   5        $ 
buttonNext��57      $��3��6)   #��[  69   
�������$��>��58   7   {�6   �� *CanMoveNext+67    � Triggers 59      :� 5:       :� RoutedEvent$ Button.Click��6    :� 
SourceName$ 
buttonNext��6:   [�5;      �� 5<      .��5=      �� .��5>   "   ��  �� 
TargetName$ ControlPanelBrush��61    �� TargetProperty$ Color�6[    g� Duration$ 00:00:1D�5?   F   	 �� To 6%   �� *ControlPanelColor+5@   #   5A      5B      5D      :� 5F      $ Button.Click��6   $ buttonPrevious��6:   [�5G      �� 5H      .��5I      �� .��5J   "   �� $ ControlPanelBrush��61   $ Color�6[   $ 00:00:1D�5K   F    6%   �� *ControlPanelColor+5L   #   5M      5N      5P      5T      5U      5V      