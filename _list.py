# li=[1,3,5,'s']
# l=[2,5,6,4,9,5]
# print(li[-1])
# li.append((4,5)) #增加串列成員在末尾(只能增加一個成員)
# print(li)
# print(li.count(2)) #數有幾個2
# li.extend([2,3,5,7]) #在原串列中加入新串列並合併
# print(li)
# print(li.index(5)) #標示5的位置(只會標示編號最小的)
# li.insert(3,'david is handsome') #在指定位置插入串列
# print(li)
# li.pop(3) #將第四個資料刪除並回傳值
# print(li)
# print(li.pop(3)) #印出第四個資料的值
# li.remove(5) #刪除第一個遇到的五
# print(li)
# li.reverse()
# print(li)
# l.sort() #數字由小排到大
# print(l)
dic={'langsam':'slow','schnell':'fast','groß':'big','zwei':2}
d=dic.copy() #複製字典
dic.clear() #清空字典
print(dic,d)
d['ezmil']='dope'
print(d['ezmil'])
k=d.items()
print(k)
print(d.keys())
d.update({'kick':3}) 
d.pop('langsam') #刪除langsam
d.values() #值的串列
