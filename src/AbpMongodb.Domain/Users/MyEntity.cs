﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Volo.Abp.Domain.Entities;

namespace AbpMongodb.Users
{
    public class MyEntity : Entity<string>
    {
        public MyEntity(string id)
        {
            this.Id = id;
        }

        //使用ObjectId作为Id（_id）字段的类型，是mongodb的最佳实践
        //一般，有两种方式来配置：

        //方式一：
        //在C#中使用string类型，加上[BsonRepresentation(BsonType.ObjectId)]，映射到Mongodb中，字段类型就是ObjectId
        //官方文档地址-设置字段类型为ObjectId：https://mongodb.github.io/mongo-csharp-driver/2.10/reference/bson/mapping/#objectids

        //方式二：
        //还有一种方式时在DbContext的CreateModel中进行配置（类似EF）
        //详见：AbpMongodb.MongoDB.AbpMongodbMongoDbContext


        //遇到的问题：无法将Id字段的类型设置为ObjectId
        //方式一：Id字段被Abp封装在Entity中，无法为其添加[BsonRepresentation(BsonType.ObjectId)]
        //方式二：会报异常：
        //System.ArgumentOutOfRangeException: The memberInfo argument must be for class MyEntity, but was for class Entity`1. (Parameter 'memberInfo')


        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        public string Name { get; set; }
    }
}
