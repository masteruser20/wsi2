   M S B A M L   `   `   `  ����>  :WSI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WSIWSI  5          WSI.Management   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:WSI     5        N� Title$  
Management��5      .��5
      � $
��Left=�6   $	��Top=�6&   $	��470��6>   $��10q�6J    � RowDefinitions 5   
   �� 5      �� 5      �� 5      $��25 �6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��4* �6   6,   �� 5      $��2* �6   6,   �� 5      $��3* �6   6,   �� 5      $��2* �6   6,   .+�5   
   �� $��0��6   $��0��6   .��6-   Dodawanie słownika6A   �� 5   
   -   5         ��Name$ openFileTextBox��5      $��1��6+   $��0��68   $
��Left=�6H    �� 
IsReadOnly .  �� TextWrapping$ NoWrap=�6u    �� TextAlignment$ Right=�6�   $	��Top=�6�   $	��171��6�   $��24��6�   �� 5   
   -   5         ��Name$ loadDictionaryBtn��5      $��1��6,   $��1��69   $��Wybierz��6I   $
��Left=�6[   $	��Top=�6v   $��75��6�   $��24��6�   $��10,0,0,0q�6�   6�   �� 5   
   -   5        $ dictionaryName��5      $��1��6*   $��Nazwa slownika...��67   $��2��6P   $
��Left=�6`   $
 Wrap=�6{   $	��Top=�6�   $��5,0,0,0q�6�   $	��113��6�   $��24��6�   $��13.333(�6�   �� 5   
   -   5        $ saveDictionaryBtn��5      $��3��6,   $��1��6<   $��Wczytaj��6I   $��5,0,0,0q�6[   6�   �� 5   
   $��2��6   $��0��6   .��6-   Usuwanie słownika6@   �� 5    
   -   5         ��Name$ DictionariesList��5    C   	 �� Text$	 Słowniki...��6   $��0��6&   $��3��66   5!      �� 5#   
   -   5        $ deleteDictionaryBtn��5#       $��Usuń��6   $��3��6=   $��1��6J   $��1q�6Z   $��10,0,0,0q�6n   6�   5$      5%      