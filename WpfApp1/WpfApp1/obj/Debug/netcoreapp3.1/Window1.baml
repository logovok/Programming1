   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          �Name$  ___Без_имени_��5   	    � Title$ Window1��5   	   $	��450��6   $	��800��6&    � SizeToContent$ Manual=�62    � WindowStyle$
 None=�6I    � 
ResizeMode$ NoResize=�6\   .��5	      � $��	0,10,0,-6q�6   ��5
   
   
� 5      .��5      �  � Color$ 	#FF40FFF5��6   � 5      $ 	#FF00FFCD��6    � Offset$ 1Q�61   5      .+�5   
   �� -   5        $
��Back��5      $
��Left=�6    $��77��6;   $��605,324,0,0q�6G   $	��Top=�6\   $	��147��6t   ���	#FFF37E7E6�   �� 5   
   -   5         ��Name$	 TB1��5      $
��Left=�6   $��36��6:   $��
58,217,0,0q�6F    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6n   $	��152��6�   $��№ of students ticket��6�   �� 5   
   -   5        $	 TB2��5      $
��Left=�6   $��36��6:   $��215,217,0,0q�6F   $��Firstname Secondname��6[   $
 Wrap=�6w   $	��Top=�6�   $	��185��6�   �� 5   
   -   5        $	 TB3��5      $
��Left=�6   $��52��6:   $��
58,280,0,0q�6F   $/��)Any personal data you would like to apply��6Z   $
 Wrap=�6�   $	��Top=�6�   $	��342��6�   �� 5   
   -   5        	 ��Name$
	 BTN1��5      $��Add to base��6   $
��Left=�65   $��69��6P   $��
58,332,0,0q�6\   $	��Top=�6p   $	��171��6�   6�   �� 5   
   -   5        $
	 BTN2��5      $��Remove by id��6   $
��Left=�66   $��69��6Q   $��234,332,0,0q�6]   $	��Top=�6r   $	��166��6�   6�   �� 5   
   -   5        $		 FLB��5      $��FLUSH��6   $
��Left=�6.   $��96��6I   $��
423,62,0,0q�6U   $	��Top=�6i   $	��329��6�   ���	#FF7EB6F3���	#FFC3C0C06�   �� 5   
   -	   5        
 ��Name$

 CHB1��5      $��OptemizedMode��6!   $
��Left=�69   $��23��6T   $��	58,87,0,0q�6`   $	��Top=�6s   $	��171��6�   $��20(�6�   �� 5   
   $
��Left=�6   $��79��6/   $��
58,142,0,0q�6;   $����Різниця між оптимізованим та не оптимізованим режимом полягає в тому, зо без нього файл перезаписуватиметься при кожному натисканні кнопки Додати або Стерти запис, а у оптимізованому запис буде лише при натисканні FLUSH��6O   $
��Wrap=�62  $	��Top=�6F  $	��342��6^  ${�False��6j  5      5      