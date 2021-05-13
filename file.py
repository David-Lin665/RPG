#開啟並儲存檔案再關閉
# xfile=open('linear algebra.txt',mode='w',encoding='Utf-8')
# xfile.write("吃葡萄不吐葡萄皮\n不吃葡萄不吐葡萄皮")
# xfile.close()
#另一種更佳的寫法
with open('lacivious.txt',mode='w',encoding='Utf-8')as file:
    file.write('為這個美好的世界獻上祝福')


