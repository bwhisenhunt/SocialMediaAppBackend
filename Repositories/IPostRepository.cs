

using Backend.Models;

namespace Backend.Repositories;
public interface IPostRepository
{
    IEnumerable<Post> GetAllPosts();
    Post? GetPostById(int postId);
    Post CreatePost(Post newPost);
    Post? UpdatePost(Post newPost);
    void DeletePostById(int postId);

}