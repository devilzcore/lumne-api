export interface Post {
  id: number,
  title: string,
  image: string,
  summary: string,
  content: string,
  readingTime: number,
  categories: string[],
  postedAt: Date,
  enumPostPermission: string
}
