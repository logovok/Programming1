   M S B A M L   `   `   `  ����H  DWPF2Indntfyer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF2IndntfyerWPF2Indntfyer  5   	       WPF2Indntfyer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WPF2Indntfyer     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $��Center=�65   $��Center=�6W   4  .System.Windows.Automation.AutomationProperties   IsOffscreenBehavior$ Default=�6{    � WindowStyle$ SingleBorderWindow=�6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ ButLR1��5      $��LearningMode��6!   $��40,160,20,0q�68   $��36(�6M   $��Rockwell Condensed)�6[    K� ZIndex$ 1��6�   $��75��6�   $	��Top=�6�   �� 5   
   -   5        $ ButLR2��5      $��DetectionMode��6!   $��20,160,40,0q�69   $��36(�6N   $��Rockwell Condensed)�6\   $ 1��6|   $��1��6�   $��75��6�   $	��Top=�6�   �� 5   
   -   5        $ BTNex��5      $
��EXIT��6    $
��Left=�6/   $��59��6J   $��227,334,0,0q�6V   $	��Top=�6k   $	��133��6�   $��1��6�   �� 5   
   $��0,0,0,0q�6   
���   � J� RenderTransformOrigin$ 0.5,0.5&�6?    � IsSharedSizeScope$
 True��6_   ��5      �� 5       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   
 � SpreadMethod$
 Repeat=�6J    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$	 0.5Q�6-    �� CenterX$	 0.5Q�6;    �� ScaleY$ -1Q�6I   �� 5       �� CenterY$	 0.5Q�6,    �� CenterX$	 0.5Q�6:   �� 5       �� Angle$	 -45Q�6.    �� CenterY$	 0.5Q�6:    �� CenterX$	 0.5Q�6H   T� 5      5      .��5      �  � Color$ Black��6#   � 5      $ 	#FFEBFF00��6#    � Offset$ 1Q�65   5      5       �� 5!   
   $��0,0,0,0q�6   
���   �$	 0,1&�6?   $��1��6[   $
 True��6k   $��LeftToRight=�6�   $��0,0,0,0q�6�    � BindingGroup 5"      &   System.Windows.Data.BindingGroup  5#      ��5%      �� 5&      $ 0.5,1&�6&   $	 0.5,0&�67   $
 Repeat=�6J    5'      V� 5(      .~�5)      �� $	 0.5Q�6-   $	 0.5Q�6;   $ -1Q�6I    �� ScaleX$ -1Q�6U   �� 5*      $	 0.5Q�6,   $	 0.5Q�6:   �� 5+      $ 45Q�6.   $	 0.5Q�69   $	 0.5Q�6G   T� 5,      5-      .��5/      � $ Black��6#   $ 0Q�61   � 50      $ 	#FFEBFF00��6#   $ 1Q�65   51      53      �� 54   
   -   5         ��Name$
 ExBx��54      $��350,0,350,14q�6"   $
��EXIT��68   $
��Wrap=�6D   $��48(�6X   $��2��6�   $��80��6�   $��Bottom=�6�   $	��100��6�   56      57      