import sys
import pandas as pd
import pyodbc
import time
from datetime import datetime

# C:\Users\j.leija\Downloads\MSOnlineCapture_20210825121952.xlsx
# C:\Users\j.leija\Downloads\MSOnlineCapture_20210824160331.xlsx

def upload_batch(batch):
    print("starting online db copy update")
    conn_nfl = pyodbc.connect('Driver={SQL Server};'
                      'Server=elpuatsqlserver.database.windows.net;'
                      'UID=azureuser;'
                      'PWD=elp.1234;'
                      'Database=db_elptest;') 
    print("nfl connection success")
    print("")
    print("")
    print("batch to process:" + str(batch.shape))
    print("")
    print("")
    print(batch)

    print("")
    print("")
    inserted_lines = 0;
    for row in batch.iterrows():
        onlineId = row[1][0]
        
        if not(IsExistingId(onlineId,conn_nfl)):
           insertLine(row,conn_nfl)
           print("line inserted: " + str(onlineId))
           inserted_lines +=1

    return inserted_lines
                       
        

def insertLine(row,conn):
    conn_nfl = pyodbc.connect('Driver={SQL Server};'
                          'Server=elpuatsqlserver.database.windows.net;'
                          'UID=azureuser;'
                          'PWD=elp.1234;'
                          'Database=db_elptest;')
    
    cursor = conn_nfl.cursor()
    
    insert_string = "INSERT INTO dbo.tbl_MSFTOnline_Detail  VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')".format(row[1][0],row[1][1],row[1][2],row[1][3],row[1][4],row[1][5],
                                             row[1][6],row[1][7],row[1][8],row[1][9],row[1][10],
                                             row[1][11],row[1][12],row[1][13],row[1][14],row[1][15],
                                             row[1][16],row[1][17],row[1][18],row[1][19],row[1][20])
    print("query:")
    print(insert_string)
    cursor.execute(insert_string)
    conn_nfl.commit()
                                             
                                             
                                             

    

def IsExistingId(onlineId,conn):
    cursor = conn.cursor()
    query_string = "SELECT COUNT(*) FROM dbo.tbl_MSFTOnline_Detail DETAIL WHERE DETAIL.onlineId = '{0}'".format(onlineId)
    cursor.execute(query_string)
    count = int(cursor.fetchall()[0][0])
    if(count):
        return True
    else:
        return False
    

# main procedure
start_time = datetime.now()

filename = sys.argv[1]

dataframe = pd.read_excel(filename)

print('running python process file')
print('arguments received:')
print('file name: ' + filename)

print('total lines inserted: ' + str(upload_batch(dataframe)))



print('process completed.')
print('process time = ' + str(datetime.now()-start_time))
