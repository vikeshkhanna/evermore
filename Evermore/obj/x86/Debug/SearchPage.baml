   M S B A M L   `   `   `  ����  Evermore    Evermore.SearchPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $
��Auto��5   7   $
��Auto��6E   .��5      �   � RowDefinitions  5	   
   �� 5
      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   �� -   5         ��Name$ SearchPageHeader��5      $��0��6*   $��1��67   $	��Top=�6G   $
��Left=�6_      PageHeaderLabelStyle#��[  6z   .��6�   	Searching6�   �� 5   
   -   5        $ ProgressLabel��5      $��2��6'   $��1��64   $��16(�6D   $	��Top=�6R   ��6j   �� *SearchProgressLabelContent+ �� FallbackValue$ Looking in C:\��6�   �� 5   
   -   5        $ ProgressLabelSecondary��5      $��3��60   $��1��6=   $��12(�6M   $	��Top=�6[   
���  ��$��Please wait...��6�   ��5      �� 5       �� 
TargetType" ��6    �� Triggers 5      �� 5        �� Binding 6"   ��  �� Path$ IsSearchComplete� �� Value True6L   	 N� EnterActions	 5!      �� 5"      .��5#   "   �� .��5$   &   W� 
 �� TargetProperty$
 Opacity�66    W� From$ 1X�6Z   	 W� To$ 0X�6c    g� Duration$ 0:0:1D�6j   5%   #   5&      .a�5(      ��  �� Property � y� �� Value$ Hidden=�67   5)      �� 5*       6"   �� $ IsSearchComplete�	 False6L   	 5+      �� 5,   "   .��5-   &   �� .��5.   *   W� $
 Opacity�6:   $ 0X�6^   $ 1X�6g   $ 0:0:1D�6n   5/   '   50   #   .a�52      ��  � y�$ Visible=�6;   53      55      57      �� 59   
   -   5         ��Name$ FoundFilesComboBox��59      $��5��6/   $��1��6<    J� Opacity$ 0Q�6L   ��5:      �� 5;      " ��6    5<      �� 5=       6&   �� $ IsFileFound� True6K   	 5>      �� 5?   "   .��5@   &   �� .��5A   *   W� $
 Opacity�6:   $ 0X�6^   $ 1X�6g   $ 0:0:2D�6n   5B   '   5C   #   .a�5E      ��  � y�$ Visible=�6;   5F      �� 5G       6&   �� $ IsFileFound�	 False6K   .a�5H      ��  � y�$ Hidden=�6;   5I      5K      5M      �� 5O   
   $y�Hidden=�6   $��7��6%   $��1��62     MetroDialogButton#��[ 6C   $
��Left=�6n   
�������.��6�   Cancel6�   5P   	   5Q      